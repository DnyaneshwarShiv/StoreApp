using Microsoft.EntityFrameworkCore;

namespace StoreApp.Domain.ExtraEdgeStoreDB
{
    public partial class ExtraEdgeStoreDBContext : DbContext
    {
        public ExtraEdgeStoreDBContext()
        {
        }

        public ExtraEdgeStoreDBContext(DbContextOptions<ExtraEdgeStoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Mobile> Mobile { get; set; }
        public virtual DbSet<PaymentModeMaster> PaymentModeMaster { get; set; }
        public virtual DbSet<Promotion> Promotion { get; set; }
        public virtual DbSet<UserMobileOrder> UserMobileOrder { get; set; }
        public virtual DbSet<UserOrder> UserOrder { get; set; }
     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=SILICUS543\\SQLEXPRESS2017;Database=ExtraEdgeStoreDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Mobile>(entity =>
            {
                entity.Property(e => e.Brand).HasMaxLength(600);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Model).HasMaxLength(800);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<PaymentModeMaster>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasMaxLength(100);

                entity.Property(e => e.PaymentType).HasMaxLength(800);
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasMaxLength(100);

                entity.Property(e => e.PromoCodeName).HasMaxLength(800);

                entity.Property(e => e.PromoCodeType).HasMaxLength(500);
            });

            modelBuilder.Entity<UserMobileOrder>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.MobileId).HasMaxLength(100);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasMaxLength(100);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserOrder>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasMaxLength(100);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderName).HasMaxLength(100);
            });

          
        }
    }
}
