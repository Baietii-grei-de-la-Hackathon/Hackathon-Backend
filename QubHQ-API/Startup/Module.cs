using Hackathon_Backend.Settings;
using Microsoft.EntityFrameworkCore;
using QubHq_Repo;
using QubHq_Repo.UnitOfWork;
using QubHQ_Services.Services;
using QubHQ_Services.Services.Item;
using QubHQ_Services.Services.TransactionService;
using QubHQ_Services.Services.VerifyService;

namespace Hackathon_Backend.Startup;

public static class Module
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<QubHQDbContext>(options =>
            options.UseSqlServer(connectionString, x => x.MigrationsAssembly("QubHQ-Repo")));
        
        services.AddScoped<IVeryfiService, VeryfiService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddTransient<ITransactionService, TransactionService>();
        services.AddTransient<IItemService, ItemService>();
        
        services.AddOptions<VeryfiSettings>().BindConfiguration("VeryfiSettings");
        
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.ConfigureCors();
        services.AddHttpClient();
    }
    
    private static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(o =>
        {
            o.AddDefaultPolicy(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
            );
        });
    }
}