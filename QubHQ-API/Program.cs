using Hackathon_Backend.Startup;
using Microsoft.EntityFrameworkCore;
using QubHq_Repo;
using QubHq_Repo.UnitOfWork;
using QubHQ_Services.Services;

namespace Hackathon_Backend;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.ConfigureServices(builder.Configuration);
        
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

        app.UseCors();

        app.Run();
    }
}