
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using StringCalculator.Application.Interfaces;
using StringCalculator.Application.Services;
using StringCalculator.Core.Interfaces;
using StringCalculator.Core.Specifications;
using StringIntegerCalculator_API.ExceptionMiddlewareHandler;
using System.Text;

namespace StringIntegerCalculator_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddLogging(loggingBuilder =>
            {
                // Set up Serilog
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.File("C:/UlCodingTask/Logs/app.log") // Specify the log file name
                    .CreateLogger();

                loggingBuilder.AddSerilog();
            });
            // Added JWT Authentication and Authorization
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; 
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("Jwt:Key"))), // Replace with your secret key
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});
            builder.Services.AddControllers();
            builder.Services.AddScoped<ITokenService, TokenService>();
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