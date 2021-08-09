using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Foodilizer_Group35.Models
{
    [Table("customer")]
    [Index(nameof(Email), Name = "email", IsUnique = true)]
    [Index(nameof(LocationLink), Name = "location_link", IsUnique = true)]
    [Index(nameof(Nic), Name = "nic", IsUnique = true)]
    [Index(nameof(ProfileImage), Name = "profile_image", IsUnique = true)]
    [Index(nameof(Username), Name = "username", IsUnique = true)]
    public partial class Customer
    {
        [Key]
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("nic")]
        [StringLength(50)]
        public string Nic { get; set; }
        [Column("username")]
        [StringLength(50)]
        public string Username { get; set; }
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; }
        [Column("district")]
        [StringLength(50)]
        public string District { get; set; }
        [Column("province")]
        [StringLength(50)]
        public string Province { get; set; }
        [Column("address")]
        [StringLength(50)]
        public string Address { get; set; }
        [Column("pref_food_type")]
        [StringLength(50)]
        public string PrefFoodType { get; set; }
        [Column("dietry_restriction")]
        [StringLength(50)]
        public string DietryRestriction { get; set; }
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("location_link")]
        [StringLength(200)]
        public string LocationLink { get; set; }
        [Column("profile_image")]
        [StringLength(200)]
        public string ProfileImage { get; set; }
    }
}
