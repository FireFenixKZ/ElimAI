using System.ComponentModel.DataAnnotations;

namespace Identity.API.DTO
{
    public class UserLoginDTO
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public RoleDTO Role { get; set; } = RoleDTO.Customer;
    }
}
