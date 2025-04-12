using Microsoft.EntityFrameworkCore;
using QubHq_Repo.Enums;
using QubHq_Repo.Models;
using Transaction = QubHq_Repo.Models.Transaction;

namespace QubHq_Repo;

public class QubHQDbContext : DbContext
{
    public QubHQDbContext(DbContextOptions<QubHQDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<User> Payees { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Transaction>()
            .HasMany(p => p.Users)
            .WithOne(p => p.Transaction)
            .HasForeignKey(p => p.TransactionId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); 

        builder.Entity<User>()
            .Property(t => t.DidPay)
            .HasDefaultValue(false);   
        
        builder.Entity<User>()
            .Property(t => t.IsPayee)
            .HasDefaultValue(false);

        builder.Entity<Transaction>()
            .Property(t => t.Date)
            .HasDefaultValue(DateTime.UtcNow);
        
        builder.Entity<Transaction>()
            .Property(t => t.PaidToRestaurant)
            .HasDefaultValue(false);
        
        builder.Entity<TransactionStatus>()
            .Property(e => e.Id)
            .ValueGeneratedNever();
        
        builder.Entity<TransactionStatus>().HasData(
            Enum.GetValues(typeof(TransactionStatusEnum))
                .Cast<TransactionStatusEnum>()
                .Select(e => new TransactionStatus
                {
                    Id = (int)e,
                    Name = e.ToString()
                })
        );
    }
}