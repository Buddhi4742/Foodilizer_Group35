using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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
        [StringLength(200)]
        public string Rname { get; set; }
        [Column("owner_name")]
        [StringLength(200)]
        public string OwnerName { get; set; }
        [Column("owner_contact")]
        [StringLength(10)]
        public string OwnerContact { get; set; }
        [Column("owner_email")]
        [StringLength(200)]
        public string OwnerEmail { get; set; }
        [Column("rabout")]
        [StringLength(500)]
        public string Rabout { get; set; }
        [Column("rest_type")]
        [StringLength(200)]
        public string RestType { get; set; }
        [Required]
        [Column("remail")]
        [StringLength(200)]
        public string Remail { get; set; }
        [Column("raddress")]
        [StringLength(500)]
        public string Raddress { get; set; }
        [Column("rdistrict")]
        [StringLength(200)]
        public string Rdistrict { get; set; }
        [Column("price_range")]
        [StringLength(200)]
        public string PriceRange { get; set; }
        [Column("rusername")]
        [StringLength(200)]
        public string Rusername { get; set; }
        [Column("rpassword")]
        [StringLength(200)]
        public string Rpassword { get; set; }
        [Column("rprovince")]
        [StringLength(200)]
        public string Rprovince { get; set; }
        [Column("open_hour")]
        [StringLength(200)]
        public string OpenHour { get; set; }
        [Column("open_status")]
        public int? OpenStatus { get; set; }
        [Column("website_link")]
        public string WebsiteLink { get; set; }
        [Column("map_link")]
        public string MapLink { get; set; }
        [Column("meal_type")]
        [StringLength(200)]
        public string MealType { get; set; }
        [Column("cuisine")]
        [StringLength(200)]
        public string Cuisine { get; set; }
        [Column("feature")]
        [StringLength(200)]
        public string Feature { get; set; }
        [Column("special_diet")]
        [StringLength(100)]
        public string SpecialDiet { get; set; }
        [Column("rest_contact")]
        [StringLength(10)]
        public string RestContact { get; set; }

        public virtual User RemailNavigation { get; set; }
        [InverseProperty("Rest")]
        public virtual RestaurantImage RestaurantImage { get; set; }
        [InverseProperty(nameof(CustomAccount.Rest))]
        public virtual ICollection<CustomAccount> CustomAccounts { get; set; }
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
    }
}
