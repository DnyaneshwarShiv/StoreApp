using Microsoft.EntityFrameworkCore;

namespace StoreApp.Domain.ClientDB
{
    public partial class ClientDBContext : DbContext
    {
        public ClientDBContext()
        {
        }

        public ClientDBContext(DbContextOptions<ClientDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=SILICUS543\\SQLEXPRESS2017;Database=ClientDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasMaxLength(100);

                entity.Property(e => e.StoreDbname)
                    .HasColumnName("StoreDBName")
                    .HasMaxLength(800);
            });
            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(500);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(80);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(30);

                entity.Property(e => e.Mobile).HasMaxLength(15);
                entity.Property(e => e.ClientId).HasMaxLength(15);
                entity.Property(e => e.Password).HasMaxLength(800);
                entity.Property(e => e.Token).HasMaxLength(800);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(800);
            });
        }
    }
}
