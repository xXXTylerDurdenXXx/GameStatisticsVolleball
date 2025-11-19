using GameStatisticsVolleball.Models;
using GameStatisticsVolleball.Models.DTO;

namespace GameStatisticsVolleball.Service
{

    public class AuthService : IAuthService
    {
        public AuthResponse Login(LoginRequest loginRequest)
        {
            throw new NotImplementedException();
        }

        public AuthResponse RefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public AuthResponse Register(CreateUserRequest createUserRequest)
        {
            throw new NotImplementedException();
        }

        public bool ValidateToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
