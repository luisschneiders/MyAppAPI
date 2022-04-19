using System;
namespace HealthCareAPI.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;

        // Retrieve API keys from user-secrets
        private readonly IConfiguration _config;

        private string _apiKey = "HealthCareAPIKey";

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var middlewareAPIKey = _config["HealthCareAPI:MiddlewareAPIKey"];

            if(!context.Request.Headers.TryGetValue(_apiKey, out var extractedAPIKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API key was not provided, please check!");
                return;
            }

            if(!middlewareAPIKey.Equals(extractedAPIKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorised client!");
                return;
            }
            await _next(context);
        }
    }
}
