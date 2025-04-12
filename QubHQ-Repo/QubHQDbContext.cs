using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QubHq_Repo.Enums;
using QubHq_Repo.GenericEnumFunctions;
using QubHq_Repo.Models;
using Transaction = QubHq_Repo.Models.Transaction;

namespace QubHq_Repo;

public class QubHQDbContext : IdentityDbContext<User>
{
    public QubHQDbContext(DbContextOptions<QubHQDbContext> options) : base(options)
    {
    }

    public override DbSet<User> Users { get; set; }
    public DbSet<Payer> Payees { get; set; }
    public DbSet<Transaction> Transactions { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>()
            .HasMany(t => t.Transactions)
            .WithOne(u => u.Payee)
            .HasForeignKey(u => u.PayeeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<User>()
            .HasMany(t => t.Payees)
            .WithOne(u => u.Account)
            .HasForeignKey(u => u.AccountId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Transaction>()
            .HasMany(p => p.Payers)
            .WithOne(p => p.Transaction)
            .HasForeignKey(p => p.TransactionId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Transaction>()
            .Property(t => t.Status)
            .HasDefaultValue(TransactionStatusEnum.Pending);

        builder.Entity<Transaction>()
            .Property(t => t.Date)
            .HasDefaultValue(DateTime.UtcNow);

        builder.Entity<TransactionStatus>()
            .HasData(EnumFunctions.GetModelsFromEnum<TransactionStatus, TransactionStatusEnum>());
    }
}