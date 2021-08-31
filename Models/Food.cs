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
        public Food()
        {
            FoodRecommendationFood1s = new HashSet<FoodRecommendation>();
            FoodRecommendationFood2s = new HashSet<FoodRecommendation>();
            FoodRecommendationFood3s = new HashSet<FoodRecommendation>();
            FoodRecommendationFood4s = new HashSet<FoodRecommendation>();
            FoodRecommendationFood5s = new HashSet<FoodRecommendation>();
        }

        [Key]
        [Column("food_id")]
        public int FoodId { get; set; }
        [Column("menu_id")]
        public int FoodName { get; set; }
        [Column("name")]
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

        [ForeignKey(nameof(MenuId))]
        [InverseProperty("Foods")]
        public virtual Menu Menu { get; set; }
        [InverseProperty(nameof(FoodRecommendation.Food1))]
        public virtual ICollection<FoodRecommendation> FoodRecommendationFood1s { get; set; }
        [InverseProperty(nameof(FoodRecommendation.Food2))]
        public virtual ICollection<FoodRecommendation> FoodRecommendationFood2s { get; set; }
        [InverseProperty(nameof(FoodRecommendation.Food3))]
        public virtual ICollection<FoodRecommendation> FoodRecommendationFood3s { get; set; }
        [InverseProperty(nameof(FoodRecommendation.Food4))]
        public virtual ICollection<FoodRecommendation> FoodRecommendationFood4s { get; set; }
        [InverseProperty(nameof(FoodRecommendation.Food5))]
        public virtual ICollection<FoodRecommendation> FoodRecommendationFood5s { get; set; }
    }
}
