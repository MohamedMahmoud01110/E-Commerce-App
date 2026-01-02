using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Web.Middlewares
{
    public class GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
                if (context.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    var problem = new ProblemDetails
                    {
                        Title = "Error Processing The HTTP Request - End Point Not Found",
                        Detail = $"End Point {context.Request.Path} Was Not Found",
                        Instance = context.Request.Path,
                        Status = StatusCodes.Status404NotFound,
                    };
                    await context.Response.WriteAsJsonAsync(problem);
                }

            }
            catch (Exception ex)
            {
                // logging
                logger.LogError("Something Went Wrong {Message}", ex.Message);
                // write response
                // set Http response status code
                // create response object
                var problem = new ProblemDetails
                {
                    Title = "Error Processing The HTTP Request",
                    Detail = ex.Message,
                    Instance = context.Request.Path,
                    Status = StatusCodes.Status500InternalServerError,
                };

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsJsonAsync(problem);
            }

        }
    }


    public static class GlobalExceptionHandlerExtensions
    {
        public static WebApplication UseCustomExceptionHandler(this WebApplication app)
        {
            app.UseMiddleware<GlobalExceptionHandler>();
            return app;

        }
    }

}
