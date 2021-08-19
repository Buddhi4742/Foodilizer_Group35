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
    [Table("customer")]
    [Index(nameof(Cemail), Name = "idx_customer_email", IsUnique = true)]
    [Index(nameof(LocationLink), Name = "location_link", IsUnique = true)]
    [Index(nameof(Nic), Name = "nic", IsUnique = true)]
    [Index(nameof(ProfileImage), Name = "profile_image", IsUnique = true)]
    [Index(nameof(Username), Name = "username", IsUnique = true)]
    public partial class Customer
    {
        public Customer()
        {
            RestaurantOrders = new HashSet<RestaurantOrder>();
            Reviews = new HashSet<Review>();
        }

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
        [StringLength(100)]
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
        [Required]
        [Column("cemail")]
        [StringLength(50)]
        public string Cemail { get; set; }
        [Column("location_link")]
        [StringLength(200)]
        public string LocationLink { get; set; }
        [Column("profile_image")]
        [StringLength(200)]
        public string ProfileImage { get; set; }

        public virtual User CemailNavigation { get; set; }
        [InverseProperty(nameof(RestaurantOrder.Customer))]
        public virtual ICollection<RestaurantOrder> RestaurantOrders { get; set; }
        [InverseProperty(nameof(Review.Customer))]
        public virtual ICollection<Review> Reviews { get; set; }
        public void ShaEnc()
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(Password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                Password = builder.ToString();
            }
        }
    }
}
