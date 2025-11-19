using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameStatisticsVolleball.Service;
using GameStatisticsVolleball.Models.DTO;
using GameStatisticsVolleball.Models;


namespace GameStatisticsVolleball.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _userService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService userService, ILogger<AuthController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        
        [HttpPost("Login")]
        public ActionResult<AuthResponseDTO> Login([FromBody] LoginRequest dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(
                        new AuthResponse
                        {
                            Success = false,
                            ErrorMessage = "входные данные некорректны"
                        });


                }

                _logger.LogInformation("Пользователь {user} запросил аутентификацию", dto.LoginOrEmail);

                var result = _userService.Login(dto);

                if (!result.Success)
                {
                    _logger.LogWarning("Пользователь {user} не смог войти", dto.LoginOrEmail);

                    return Unauthorized(new AuthResponse
                    {
                        Success = false,
                        ErrorMessage = "Неверный email или пароль"
                    });
                }

                _logger.LogInformation("Пользователь {user} успешно авторизован", dto.LoginOrEmail);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ошибка аутентификации: {message}", ex.Message);

                return StatusCode(500, new AuthResponse
                {
                    Success = false,
                    ErrorMessage = "Внутренняя ошибка сервера"
                });
            }
        }

        [HttpPost("Register")]
        public ActionResult<AuthResponse> Register([FromBody] CreateUserRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(
                        new AuthResponse
                        {
                            Success = false,
                            ErrorMessage = "входные данные некорректны"
                        });
                }
                _logger.LogWarning("пользователь {username} не прошел аутентификацию. данные не корректны", request.Login);

                var result = _userService.Register(request);
                if (!result.Success)
                {
                    return Unauthorized(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new AuthResponse
                    {
                        Success = false,
                        ErrorMessage = ex.Message
                    });
            }
        }
    }
}
