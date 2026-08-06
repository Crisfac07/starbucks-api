using Starbucks.Application.Abstractions;

namespace Starbucks.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task Invoke(HttpContext context) 
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "This is and exception");

                if (e is Application.Exceptions.ValidationException validationEx) 
                { 
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsJsonAsync(validationEx.Errors);
                    return;
                }


                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var error = new Error(
                    "UnexpectedError",
                    _env.IsDevelopment() 
                        ? e.ToString() 
                        : "An unexpected error occurred."
                    );

                await context.Response.WriteAsJsonAsync(error);

            }
        
        }
    }
}
