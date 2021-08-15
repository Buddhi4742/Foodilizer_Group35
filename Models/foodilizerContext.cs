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
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.CustomerId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.FoodId).ValueGeneratedNever();

                entity.Property(e => e.Featured).HasComment("If featured = YES and if not NO");

                entity.Property(e => e.Price).HasPrecision(18);
            });

            modelBuilder.Entity<FoodRecommendation>(entity =>
            {
                entity.HasKey(e => e.RecommendationId)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.RecommendationId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.ItemId).ValueGeneratedNever();

                entity.Property(e => e.ItemQuantity).HasPrecision(18);

                entity.Property(e => e.QuantityLimit).HasPrecision(18);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.MenuId).ValueGeneratedNever();
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
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.PackageId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => e.RestId)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.RestId).ValueGeneratedNever();

                entity.Property(e => e.OpenHour).IsFixedLength(true);

                entity.Property(e => e.OwnerContact).IsFixedLength(true);

                entity.Property(e => e.OwnerEmail).IsFixedLength(true);

                entity.Property(e => e.PriceRange).IsFixedLength(true);
            });

            modelBuilder.Entity<RestaurantContact>(entity =>
            {
                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.ContactNumber).IsFixedLength(true);
            });

            modelBuilder.Entity<RestaurantImage>(entity =>
            {
                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");
            });

            modelBuilder.Entity<RestaurantOrder>(entity =>
            {
                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.TotalAmount).HasPrecision(18);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Rating).HasComment("rating is saved as  one number");
            });

            modelBuilder.Entity<SalesReport>(entity =>
            {
                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Content).HasComment("Insert sales report content and any additional content");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
