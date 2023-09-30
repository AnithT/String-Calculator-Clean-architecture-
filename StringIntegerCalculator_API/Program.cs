
using StringCalculator.Application.Interfaces;
using StringCalculator.Application.Services;
using StringCalculator.Core.Interfaces;
using StringCalculator.Core.Specifications;
using StringIntegerCalculator_API.ExceptionMiddlewareHandler;

namespace StringIntegerCalculator_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IMathExpressionService, MathExpressionService>();
            builder.Services.AddScoped<IMathExpressionEvaluator, MathExpressionEvaluator>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseMiddleware<ExceptionMiddleware>();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}