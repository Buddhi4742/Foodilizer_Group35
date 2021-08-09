using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Foodilizer_Group35.Models
{
    [Table("food")]
    [Index(nameof(MenuId), Name = "fk_menu")]
    [Index(nameof(ImagePath), Name = "image_path", IsUnique = true)]
    public partial class Food
    {
        [Key]
        [Column("food_id")]
        public int FoodId { get; set; }
        [Column("menu_id")]
        public int? MenuId { get; set; }
        [Column("price")]
        public decimal? Price { get; set; }
        [Column("type")]
        [StringLength(50)]
        public string Type { get; set; }
        [Column("ingredient")]
        [StringLength(200)]
        public string Ingredient { get; set; }
        [Column("image_path")]
        [StringLength(200)]
        public string ImagePath { get; set; }
        [Column("dietry_type")]
        [StringLength(50)]
        public string DietryType { get; set; }
        [Column("pref_score")]
        public int? PrefScore { get; set; }
        [Column("featured")]
        [StringLength(5)]
        public string Featured { get; set; }
    }
}
