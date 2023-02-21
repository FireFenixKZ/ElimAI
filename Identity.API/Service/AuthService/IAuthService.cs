using Identity.API.DTO;
using Identity.API.Entity;

namespace Identity.API.Service.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<bool> UserExists(string email);
        Task<ServiceResponse<string>> Login(UserLoginDTO userLogin);
        Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword);
        int GetUserId();
        string? GetUserEmail();
        Task<User?> GetUserByEmail(string email);
    }
}
