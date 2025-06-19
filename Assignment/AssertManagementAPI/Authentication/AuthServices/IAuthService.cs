using AssertManagementAPI.Authentication.AuthDTO;

namespace AssertManagementAPI.Authentication.AuthServices
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDTO dto);
        Task<string> LoginAsync(LoginDTO dto);
        Task<string> GenerateResetTokenAsync(ForgotPasswordDTO dto);
        Task<string> ResetPasswordAsync(ResetPasswordDTO dto);

    }

}
