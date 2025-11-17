using Microsoft.AspNetCore.Identity.Data;

namespace GameStatisticsVolleball.Service
{
    using GameStatisticsVolleball.Models.DTO;
    using GameStatisticsVolleball.Models;
    public interface IAuthService
    {
        AuthResponse Login(LoginRequest loginRequest);
        AuthResponse Register(CreateUserRequest createUserRequest);
        AuthResponse RefreshToken(string refreshToken);
        bool ValidateToken(string token);
    }
}
