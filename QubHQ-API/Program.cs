using Hackathon_Backend.Startup;
using Microsoft.EntityFrameworkCore;
using QubHq_Repo;

using QubHQ_Services.Services;

namespace Hackathon_Backend;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
    
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
            
        builder.Services.AddDbContext<QubHQDbContext>(options =>
            options.UseSqlServer(connectionString, x => x.MigrationsAssembly("QubHQ-Repo")));
        

        builder.Services.AddHttpClient<VeryfiService>();

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