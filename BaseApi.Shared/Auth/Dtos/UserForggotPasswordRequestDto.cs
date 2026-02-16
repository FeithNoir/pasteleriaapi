using System.ComponentModel.DataAnnotations;

namespace Base.Shared.Auth.Dtos
{
    public class UserForggotPasswordRequestDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;
    }
}
