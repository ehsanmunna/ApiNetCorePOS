using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace corepos.Entities
{
    public partial class myPoSContext : DbContext
    {
        public myPoSContext()
        {
        }

        public myPoSContext(DbContextOptions<myPoSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<MeasurementUnit> MeasurementUnit { get; set; }
        public virtual DbSet<Permision> Permision { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PosRole> PosRole { get; set; }
        public virtual DbSet<PosUser> PosUser { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductGroup> ProductGroup { get; set; }
        public virtual DbSet<RoleUserMap> RoleUserMap { get; set; }
        public virtual DbSet<SalesMain> SalesMain { get; set; }
        public virtual DbSet<SalesSub> SalesSub { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<UserPermision> UserPermision { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=myPoS;User Id=sa; Password=Start777;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId);

                entity.Property(e => e.CustId)
                    .HasColumnName("custId")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.PersonId)
                    .HasColumnName("person_id")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_Customer_Person");
            });

            modelBuilder.Entity<MeasurementUnit>(entity =>
            {
                entity.ToTable("measurementUnit");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UnitName).HasMaxLength(10);
            });

            modelBuilder.Entity<Permision>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.PermisionName)
                    .HasColumnName("permisionName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasColumnType("text");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PosRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("posRole");

                entity.Property(e => e.RoleId)
                    .HasColumnName("roleId")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .HasColumnName("roleName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PosUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("posUser");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.PersonId)
                    .HasColumnName("person_id")
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PosUser)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_posUser_posUser");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProdId);

                entity.Property(e => e.ProdId)
                    .HasColumnName("prodId")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.GroupId).HasColumnName("groupId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PurchasePrice)
                    .HasColumnName("purchasePrice")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SalsePrice)
                    .HasColumnName("salsePrice")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SupplierId)
                    .IsRequired()
                    .HasColumnName("supplierId")
                    .HasMaxLength(50);

                entity.Property(e => e.UnitId).HasColumnName("unitId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductGroup");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Supplier");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_measurementUnit");
            });

            modelBuilder.Entity<ProductGroup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnName("groupName")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<RoleUserMap>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleUserMap)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_RoleUserMap_posRole");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RoleUserMap)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_RoleUserMap_posUser");
            });

            modelBuilder.Entity<SalesMain>(entity =>
            {
                entity.HasKey(e => e.SalesId);

                entity.Property(e => e.SalesId)
                    .HasColumnName("salesId")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.RefNo)
                    .HasColumnName("refNo")
                    .HasMaxLength(150);

                entity.Property(e => e.TotalChangeAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalDiscount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalDue).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalReceive).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<SalesSub>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DiscountInAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DiscountInPercentage).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ItemId)
                    .HasColumnName("itemId")
                    .HasMaxLength(50);

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SalseId).HasMaxLength(50);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Vat).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.SalesSub)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_SalesSub_Product");

                entity.HasOne(d => d.Salse)
                    .WithMany(p => p.SalesSub)
                    .HasForeignKey(d => d.SalseId)
                    .HasConstraintName("FK_SalesSub_SalesSub");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.CompanyAddress)
                    .HasColumnName("companyAddress")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyName)
                    .HasColumnName("companyName")
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyPhone)
                    .HasColumnName("companyPhone")
                    .HasMaxLength(50);

                entity.Property(e => e.PersonId)
                    .HasColumnName("personId")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Supplier)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_Supplier_Person");
            });

            modelBuilder.Entity<UserPermision>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.PermisionId).HasColumnName("permision_id");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Permision)
                    .WithMany(p => p.UserPermision)
                    .HasForeignKey(d => d.PermisionId)
                    .HasConstraintName("FK_UserPermision_Permision");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPermision)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserPermision_posUser");
            });
        }
    }
}
