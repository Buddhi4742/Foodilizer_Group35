using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

#nullable disable

namespace Foodilizer_Group35.Models
{
    [Table("restaurant")]
    [Index(nameof(Remail), Name = "idx_restaurant_remail", IsUnique = true)]
    public partial class Restaurant
    {
        public Restaurant()
        {
            CustomAccounts = new HashSet<CustomAccount>();
            FoodRecommendations = new HashSet<FoodRecommendation>();
            Items = new HashSet<Item>();
            Menus = new HashSet<Menu>();
            Packages = new HashSet<Package>();
            RestaurantOrders = new HashSet<RestaurantOrder>();
            Reviews = new HashSet<Review>();
            SalesReports = new HashSet<SalesReport>();
        }

        [Key]
        [Column("rest_id")]
        public int RestId { get; set; }
        [Column("rname")]
        [StringLength(50)]
        public string Rname { get; set; }
        [Column("owner_name")]
        [StringLength(50)]
        public string OwnerName { get; set; }
        [Column("owner_contact")]
        [StringLength(10)]
        public string OwnerContact { get; set; }
        [Column("owner_email")]
        [StringLength(10)]
        public string OwnerEmail { get; set; }
        [Column("rabout")]
        [StringLength(50)]
        public string Rabout { get; set; }
        [Column("rest_type")]
        [StringLength(50)]
        public string RestType { get; set; }
        [Required]
        [Column("remail")]
        [StringLength(50)]
        public string Remail { get; set; }
        [Column("raddress")]
        [StringLength(50)]
        public string Raddress { get; set; }
        [Column("rdistrict")]
        [StringLength(50)]
        public string Rdistrict { get; set; }
        [Column("price_range")]
        [StringLength(10)]
        public string PriceRange { get; set; }
        [Column("rusername")]
        [StringLength(50)]
        public string Rusername { get; set; }
        [Column("rpassword")]
        [StringLength(50)]
        public string Rpassword { get; set; }
        [Column("rprovince")]
        [StringLength(50)]
        public string Rprovince { get; set; }
        [Column("open_hour")]
        [StringLength(10)]
        public string OpenHour { get; set; }
        [Column("open_status")]
        public sbyte? OpenStatus { get; set; }
        [Column("website_link")]
        public string WebsiteLink { get; set; }
        [Column("map_link")]
        public string MapLink { get; set; }
        [Column("meal_type")]
        public string MealType { get; set; }
        [Column("cuisine")]
        public string Cuisine { get; set; }
        [Column("feature")]
        public string Feature { get; set; }
        [Column("special_diet")]
        public string SpecialDiet { get; set; }

        [InverseProperty("Rest")]
        public virtual RestaurantContact RestaurantContact { get; set; }
        [InverseProperty("Rest")]
        public virtual RestaurantImage RestaurantImage { get; set; }
        public virtual User User { get; set; }
        [InverseProperty(nameof(CustomAccount.Rest))]
        public virtual ICollection<CustomAccount> CustomAccounts { get; set; }
        [InverseProperty(nameof(FoodRecommendation.Rest))]
        public virtual ICollection<FoodRecommendation> FoodRecommendations { get; set; }
        [InverseProperty(nameof(Item.Rest))]
        public virtual ICollection<Item> Items { get; set; }
        [InverseProperty(nameof(Menu.Rest))]
        public virtual ICollection<Menu> Menus { get; set; }
        [InverseProperty(nameof(Package.Rest))]
        public virtual ICollection<Package> Packages { get; set; }
        [InverseProperty(nameof(RestaurantOrder.Rest))]
        public virtual ICollection<RestaurantOrder> RestaurantOrders { get; set; }
        [InverseProperty(nameof(Review.Rest))]
        public virtual ICollection<Review> Reviews { get; set; }
        [InverseProperty(nameof(SalesReport.Rest))]
        public virtual ICollection<SalesReport> SalesReports { get; set; }

        public void ShaEnc()
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(Rpassword));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                Rpassword = builder.ToString();
            }
        }
    }
}
