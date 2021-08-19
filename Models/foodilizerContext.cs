using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Foodilizer_Group35.Models
{
    public partial class foodilizerContext : DbContext
    {
        public foodilizerContext()
        {
        }

        public foodilizerContext(DbContextOptions<foodilizerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomAccount> CustomAccounts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<FoodRecommendation> FoodRecommendations { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<OrderIncludesFood> OrderIncludesFoods { get; set; }
        public virtual DbSet<OrderWithPayment> OrderWithPayments { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<RestaurantContact> RestaurantContacts { get; set; }
        public virtual DbSet<RestaurantImage> RestaurantImages { get; set; }
        public virtual DbSet<RestaurantOrder> RestaurantOrders { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<SalesReport> SalesReports { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("port=3307;server=localhost;user id=root;database=foodilizer;persistsecurityinfo=True;pwd=password", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<CustomAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.AccountId).ValueGeneratedNever();

                entity.HasOne(d => d.EmailNavigation)
                    .WithOne(p => p.CustomAccount)
                    .HasPrincipalKey<User>(p => p.Email)
                    .HasForeignKey<CustomAccount>(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customemail");

                entity.HasOne(d => d.Rest)
                    .WithMany(p => p.CustomAccounts)
                    .HasForeignKey(d => d.RestId)
                    .HasConstraintName("fk_custom");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasOne(d => d.CemailNavigation)
                    .WithOne(p => p.Customer)
                    .HasPrincipalKey<User>(p => p.Email)
                    .HasForeignKey<Customer>(d => d.Cemail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_custemail");
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.FoodId).ValueGeneratedNever();

                entity.Property(e => e.Featured).HasComment("If featured = YES and if not NO");

                entity.Property(e => e.Price).HasPrecision(18);

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Foods)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_menu");
            });

            modelBuilder.Entity<FoodRecommendation>(entity =>
            {
                entity.HasKey(e => e.RecommendationId)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.RecommendationId).ValueGeneratedNever();

                entity.HasOne(d => d.Food1)
                    .WithMany(p => p.FoodRecommendationFood1s)
                    .HasForeignKey(d => d.Food1Id)
                    .HasConstraintName("fk_f1");

                entity.HasOne(d => d.Food2)
                    .WithMany(p => p.FoodRecommendationFood2s)
                    .HasForeignKey(d => d.Food2Id)
                    .HasConstraintName("fk_f2");

                entity.HasOne(d => d.Food3)
                    .WithMany(p => p.FoodRecommendationFood3s)
                    .HasForeignKey(d => d.Food3Id)
                    .HasConstraintName("fk_f3");

                entity.HasOne(d => d.Food4)
                    .WithMany(p => p.FoodRecommendationFood4s)
                    .HasForeignKey(d => d.Food4Id)
                    .HasConstraintName("fk_f4");

                entity.HasOne(d => d.Food5)
                    .WithMany(p => p.FoodRecommendationFood5s)
                    .HasForeignKey(d => d.Food5Id)
                    .HasConstraintName("fk_f5");

                entity.HasOne(d => d.Rest)
                    .WithMany(p => p.FoodRecommendations)
                    .HasForeignKey(d => d.RestId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_foodrecom");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.ItemId).ValueGeneratedNever();

                entity.Property(e => e.ItemQuantity).HasPrecision(18);

                entity.Property(e => e.QuantityLimit).HasPrecision(18);

                entity.HasOne(d => d.Rest)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.RestId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_restit");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.MenuId).ValueGeneratedNever();

                entity.HasOne(d => d.Rest)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.RestId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_mr");
            });

            modelBuilder.Entity<OrderIncludesFood>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.FoodId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");
            });

            modelBuilder.Entity<OrderWithPayment>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.PaymentGatewayDetails).HasComment("payment gateway and any ther details");

                entity.HasOne(d => d.Order)
                    .WithOne(p => p.OrderWithPayment)
                    .HasForeignKey<OrderWithPayment>(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.PackageId).ValueGeneratedNever();

                entity.HasOne(d => d.Rest)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.RestId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_pckg");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => e.RestId)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.OpenHour).IsFixedLength(true);

                entity.Property(e => e.OwnerContact).IsFixedLength(true);

                entity.Property(e => e.OwnerEmail).IsFixedLength(true);

                entity.Property(e => e.PriceRange).IsFixedLength(true);

                entity.HasOne(d => d.RemailNavigation)
                    .WithOne(p => p.Restaurant)
                    .HasPrincipalKey<User>(p => p.Email)
                    .HasForeignKey<Restaurant>(d => d.Remail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_restemail");
            });

            modelBuilder.Entity<RestaurantContact>(entity =>
            {
                entity.HasKey(e => e.RestId)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.RestId).ValueGeneratedNever();

                entity.Property(e => e.ContactNumber).IsFixedLength(true);

                entity.HasOne(d => d.Rest)
                    .WithOne(p => p.RestaurantContact)
                    .HasForeignKey<RestaurantContact>(d => d.RestId)
                    .HasConstraintName("fk_rest");
            });

            modelBuilder.Entity<RestaurantImage>(entity =>
            {
                entity.HasKey(e => e.RestId)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.RestId).ValueGeneratedNever();

                entity.HasOne(d => d.Rest)
                    .WithOne(p => p.RestaurantImage)
                    .HasForeignKey<RestaurantImage>(d => d.RestId)
                    .HasConstraintName("fk_resti");
            });

            modelBuilder.Entity<RestaurantOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.TotalAmount).HasPrecision(18);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.RestaurantOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_custorder");

                entity.HasOne(d => d.Rest)
                    .WithMany(p => p.RestaurantOrders)
                    .HasForeignKey(d => d.RestId)
                    .HasConstraintName("fk_restau");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.ReviewId).ValueGeneratedNever();

                entity.Property(e => e.Rating).HasComment("rating is saved as  one number");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_cust1");

                entity.HasOne(d => d.Rest)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.RestId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_rest1");
            });

            modelBuilder.Entity<SalesReport>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.ReportId).ValueGeneratedNever();

                entity.Property(e => e.Content).HasComment("Insert sales report content and any additional content");

                entity.HasOne(d => d.Rest)
                    .WithMany(p => p.SalesReports)
                    .HasForeignKey(d => d.RestId)
                    .HasConstraintName("fk_rests");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
