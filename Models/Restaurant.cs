using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Foodilizer_Group35.Models
{
    [Keyless]
    [Table("restaurant")]
    public partial class Restaurant
    {
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
    }
}
