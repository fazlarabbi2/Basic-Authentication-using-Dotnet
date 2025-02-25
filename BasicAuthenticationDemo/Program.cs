using BasicAuthenticationDemo.Models;
using BasicAuthenticationDemo.Models.BasicAuthenticationDemo.Models;
using Microsoft.AspNetCore.Authentication;

namespace BasicAuthenticationDemo;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSingleton<IUserRepository, UserRepository>();

        builder.Services.AddAuthentication("BasicAuthentication")
            .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>
            ("BasicAuthentication", options => { });


        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            // This will use the property names as defined in the C# model
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
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