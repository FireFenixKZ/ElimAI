using Identity.API.Data;
using Identity.API.DTO;
using Identity.API.Entity;
using Identity.API.Entity.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Identity.API.Service.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(DataContext context,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException());

        public string GetUserEmail() => _httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.Name) ?? throw new InvalidOperationException();

        public async Task<ServiceResponse<string>> Login(UserLoginDTO userLogin)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.Users.Include(s => s.Role)
                .FirstOrDefaultAsync(x => x.Email.ToLower().Equals(userLogin.Email.ToLower()) && x.StatusId != 0);
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else if (!VerifyPasswordHash(userLogin.Password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong password.";
            }
            else
            {
                UserDTO loggedUser;

                switch (userLogin.Role)
                {
                    case RoleDTO.Customer:
                        {
                            var customer = await _context.Customers
                                .FirstOrDefaultAsync(s => s.UserId == user.Id);
                            if (customer == null)
                            {
                                response.Success = false;
                                response.Message = "You were not registered as a Customer";
                                return response;
                            }

                            loggedUser = new UserDTO
                            { Id = customer.Id, Email = customer.Email, Role = (int)userLogin.Role };
                            break;
                        }
                    case RoleDTO.Seller:
                        {
                            var seller = await _context.Sellers
                                .FirstOrDefaultAsync(s => s.UserId == user.Id);
                            if (seller == null)
                            {
                                response.Success = false;
                                response.Message = "You were not registered as a Seller";
                                return response;
                            }

                            loggedUser = new UserDTO { Id = seller.Id, Email = seller.Email, Role = (int)userLogin.Role };
                            break;
                        }
                    case RoleDTO.Driver:
                        {
                            var driver = await _context.DeliveryMen
                                .FirstOrDefaultAsync(s => s.UserId == user.Id);
                            if (driver == null)
                            {
                                response.Success = false;
                                response.Message = "You were not registered as a Driver";
                                return response;
                            }

                            loggedUser = new UserDTO { Id = driver.Id, Email = driver.Email, Role = (int)userLogin.Role };
                            break;
                        }
                    default:
                        {
                            response.Success = false;
                            response.Message = "invalid Role";
                            return response;
                        }
                }

                response.Data = CreateToken(loggedUser);
            }

            return response;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            if (await UserExists(user.Email))
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "User already exists."
                };
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            var userId = _context.Users.Add(new User()
            {
                Email = user.Email,
                Name = user.Name,
                Phone = user.Phone,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                RoleId = 1,
                StatusId = 1
            });
            await _context.SaveChangesAsync();
            _context.Customers.Add(new Customer()
            {
                UserId = userId.Entity.Id
            });

            return new ServiceResponse<int> { Data = user.Id, Message = "Registration successful!" };
        }

        public async Task<bool> UserExists(string email)
        {
            return await _context.Users.AnyAsync(user => user.Email.ToLower()
                .Equals(email.ToLower()));
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash =
                    hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(UserDTO user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, user.Email),
                new(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value ?? string.Empty));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(10),
                    signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "User not found."
                };
            }

            CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true, Message = "Password has been changed." };
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
