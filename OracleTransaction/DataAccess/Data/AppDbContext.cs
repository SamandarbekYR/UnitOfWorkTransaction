using Microsoft.EntityFrameworkCore;
using OracleTransaction.Entities.Banks;
using OracleTransaction.Entities.Users;

namespace OracleTransaction.DataAccess.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserCard> UserCards { get; set; }
    public DbSet<Bank> Banks { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserCard>(entity =>
        {
            entity.HasOne(u => u.Users)
                  .WithMany(c => c.UserCards)
                  .HasForeignKey(u => u.UserId)
                  .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            entity.HasIndex(c => c.CardNumber)
                  .IsUnique(true);
        });

        modelBuilder.Entity<User>()
                    .HasIndex(p => p.PhoneNumber)
                    .IsUnique(true);

        modelBuilder.Entity<Bank>()
                    .HasIndex(n => n.Name)
                    .IsUnique(true);

    }
}
