using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Foodilizer_Group35.Models
{
    [Table("food")]
    [Index(nameof(MenuId), Name = "fk_menu_idx")]
    [Index(nameof(ImagePath), Name = "image_path", IsUnique = true)]
    public partial class Food
    {
        public Food()
        {
            OrderIncludesFoods = new HashSet<OrderIncludesFood>();
        }

        [Key]
        [Column("food_id")]
        public int FoodId { get; set; }
        [Column("menu_id")]
        public int MenuId { get; set; }
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Column("type")]
        [StringLength(100)]
        public string Type { get; set; }
        [Column("price")]
        public decimal? Price { get; set; }
        [Column("ingredient")]
        [StringLength(200)]
        public string Ingredient { get; set; }
        [Column("image_path")]
        [StringLength(500)]
        public string ImagePath { get; set; }
        [Column("pref_score")]
        public int? PrefScore { get; set; }
        [Column("featured")]
        [StringLength(5)]
        public string Featured { get; set; }
        [Column("category")]
        [StringLength(100)]
        public string Category { get; set; }
        [Column("sub_category")]
        [StringLength(100)]
        public string SubCategory { get; set; }
        [Column("category_rating")]
        [StringLength(100)]
        public string CategoryRating { get; set; }
        [Column("quantity")]
        public int? Quantity { get; set; }
        [Column("veg")]
        [StringLength(5)]
        public string Veg { get; set; }
        [Column("spicy_level")]
        [StringLength(5)]
        public string SpicyLevel { get; set; }
        [Column("hot")]
        [StringLength(5)]
        public string Hot { get; set; }
        [Column("organic")]
        [StringLength(5)]
        public string Organic { get; set; }

        [ForeignKey(nameof(MenuId))]
        [InverseProperty("Foods")]
        public virtual Menu Menu { get; set; }
        [InverseProperty(nameof(OrderIncludesFood.Food))]
        public virtual ICollection<OrderIncludesFood> OrderIncludesFoods { get; set; }
    }
}
