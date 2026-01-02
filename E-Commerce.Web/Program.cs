
using E_Commerce.Domain.Contracts;
using E_Commerce.Persistence.DependancyInjection;
using E_Commerce.Service.DependencyInjection;
using E_Commerce.Web.Middlewares;
using System.Threading.Tasks;

namespace E_Commerce.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices(builder.Configuration);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();


            #region Initializer Db

            var scope = app.Services.CreateScope();
            var initializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            await initializer.InitializeAsync();


            #endregion



            ///app.Use(async (context, next) =>
            ///{
            ///    try
            ///    {
            ///        await next.Invoke(context);
            ///    }
            ///    catch (Exception ex)
            ///    {
            ///        Console.WriteLine(ex.Message);
            ///        // write response
            ///        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            ///        await context.Response.WriteAsJsonAsync(new
            ///        {
            ///            StatusCode = StatusCodes.Status500InternalServerError,
            ///            Message = ex.Message
            ///        });
            ///    }
            ///});

            //app.UseMiddleware<GlobalExceptionHandler>();
            app.UseCustomExceptionHandler(); // the extension i add


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}
