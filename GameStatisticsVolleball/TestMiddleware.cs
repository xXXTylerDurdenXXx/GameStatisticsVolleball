using System.Net;
using System.Text.Json;

namespace GameStatisticsVolleball
{
    public class TestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TestMiddleware> _logger;

        public TestMiddleware(RequestDelegate next , ILogger<TestMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);

                
                if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
                {
                    await WriteErrorAsync(context, HttpStatusCode.Unauthorized, "Unauthorized");
                }
                else if (context.Response.StatusCode == (int)HttpStatusCode.Forbidden)
                {
                    await WriteErrorAsync(context, HttpStatusCode.Forbidden, "Forbidden");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred.");

                await WriteErrorAsync(context, HttpStatusCode.InternalServerError, "Internal server error");
            }
        }

        private async Task WriteErrorAsync(HttpContext context, HttpStatusCode status, string message)
        {
            if (context.Response.HasStarted) return;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            var errorResponse = new
            {
                Status = context.Response.StatusCode,
                Error = message,
                Path = context.Request.Path,
                Timestamp = DateTime.UtcNow
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    }
}

