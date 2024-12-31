
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Infrastructure;
using Application.DbAccess.Repository;
using Application.DbAccess.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using couriernowapi.Middleware;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        //Jwt configuration starts here
        var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
        var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();
        var audience = builder.Configuration.GetSection("Jwt:Audience").Get<string>();
        //builder.Services.AddDbContext<ApplicationDBContext>();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("Jwt");

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtSettings["Issuer"],

            ValidateAudience = true,
            ValidAudience = jwtSettings["Audience"],

            ValidateLifetime = true,

            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"])),

            ClockSkew = TimeSpan.Zero // Optional: to remove default 5-minute clock skew
        };
    });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddTransient<ApplicationErrorLogs>();
        // Add services to the container.
        builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

        builder.Services.AddSwaggerGen();
        //services cors
        builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
        {
            builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
        }));
        //Dependency Injection
        builder.Services.AddPersistence(builder.Configuration);

        var app = builder.Build();
        // Custom middleware registration
        //app.UseMiddleware<ApplicationErrorLogs>();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        //app.UseMiddleware<ApplicationErrorLogs>();
        app.UseHttpsRedirection();
        app.UseCors("corsapp");
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }


}


