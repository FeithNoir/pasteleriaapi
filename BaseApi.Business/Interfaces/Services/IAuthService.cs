using Base.Shared.Auth.Auxiliar;
using Base.Shared.Auth.Dtos;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(UserRegistrationRequestDto request, string baseUrl);
    Task<AuthResult> ForgotPasswordAsync(UserForggotPasswordRequestDto request);
    Task<AuthResult> ResetPasswordAsync(ResetPasswordRequestDto model);
    Task<AuthResult> LoginAsync(UserLoginRequestDto dto);
    Task<AuthResult> ConfirmEmailAsync(string userId, string code);
}