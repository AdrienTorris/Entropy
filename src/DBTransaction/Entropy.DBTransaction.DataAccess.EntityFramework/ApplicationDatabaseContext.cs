namespace Entropy.DBTransaction.DataAccess.EntityFramework
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;

    public class ApplicationDatabaseContext : DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options)
           : base(options)
        {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionLog1>(entity =>
            {
                entity.ToTable("TRANSACTION_LOG_1");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<TransactionLog2>(entity =>
            {
                entity.ToTable("TRANSACTION_LOG_2");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");
            });
        }

        public virtual DbSet<TransactionLog1> TransactionLog1 { get; set; }
        public virtual DbSet<TransactionLog2> TransactionLog2 { get; set; }
    }
}