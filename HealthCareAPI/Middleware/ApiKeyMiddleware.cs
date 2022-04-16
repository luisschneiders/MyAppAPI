using System;
namespace HealthCareAPI.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private string _apiKey = "HealthCareAPIKey";

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if(!context.Request.Headers.TryGetValue(_apiKey, out var extractedAPIKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API key was not provided, please check!");
                return;
            }

            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();

            var apiKey = appSettings.GetValue<string>(_apiKey);

            if(!apiKey.Equals(extractedAPIKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorised client!");
                return;
            }

            await _next(context);
        }
    }
}

