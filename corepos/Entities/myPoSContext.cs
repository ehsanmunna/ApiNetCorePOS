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
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderSub> OrderSub { get; set; }
        public virtual DbSet<Permision> Permision { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PosRole> PosRole { get; set; }
        public virtual DbSet<PosUser> PosUser { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<RoleUserMap> RoleUserMap { get; set; }
        public virtual DbSet<UserPermision> UserPermision { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=myPoS;User Id=sa; Password=123;");
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

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.CostPrice)
                    .HasColumnName("costPrice")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasColumnName("product_id")
                    .HasMaxLength(50);

                entity.Property(e => e.Reorderlavel).HasColumnName("reorderlavel");

                entity.Property(e => e.SalsePrice)
                    .HasColumnName("salsePrice")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_Product");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId)
                    .HasColumnName("orderId")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customerId")
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasMaxLength(50);

                entity.Property(e => e.ShippedTo)
                    .HasColumnName("shippedTo")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<OrderSub>(entity =>
            {
                entity.ToTable("Order_Sub");

                entity.Property(e => e.OrderSubId)
                    .HasColumnName("orderSubId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasMaxLength(50);

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasMaxLength(50);

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("unit_price")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrderSub)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_Order_Sub_Item");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderSub)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Order_Sub_Order_Sub");
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

                entity.Property(e => e.Name).HasMaxLength(150);
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
