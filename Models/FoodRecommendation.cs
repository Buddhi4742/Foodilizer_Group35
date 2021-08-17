using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Foodilizer_Group35.Models
{
    [Table("food_recommendation")]
    [Index(nameof(Food1Id), Name = "fk_f1")]
    [Index(nameof(Food2Id), Name = "fk_f2")]
    [Index(nameof(Food3Id), Name = "fk_f3")]
    [Index(nameof(Food4Id), Name = "fk_f4")]
    [Index(nameof(Food5Id), Name = "fk_f5")]
    [Index(nameof(RestId), Name = "fk_foodrecom")]
    public partial class FoodRecommendation
    {
        [Key]
        [Column("recommendation_id")]
        public int RecommendationId { get; set; }
        [Column("rest_id")]
        public int? RestId { get; set; }
        [Column("food1_id")]
        public int Food1Id { get; set; }
        [Column("food2_id")]
        public int Food2Id { get; set; }
        [Column("food3_id")]
        public int Food3Id { get; set; }
        [Column("food4_id")]
        public int Food4Id { get; set; }
        [Column("food5_id")]
        public int Food5Id { get; set; }

        [ForeignKey(nameof(Food1Id))]
        [InverseProperty(nameof(Food.FoodRecommendationFood1s))]
        public virtual Food Food1 { get; set; }
        [ForeignKey(nameof(Food2Id))]
        [InverseProperty(nameof(Food.FoodRecommendationFood2s))]
        public virtual Food Food2 { get; set; }
        [ForeignKey(nameof(Food3Id))]
        [InverseProperty(nameof(Food.FoodRecommendationFood3s))]
        public virtual Food Food3 { get; set; }
        [ForeignKey(nameof(Food4Id))]
        [InverseProperty(nameof(Food.FoodRecommendationFood4s))]
        public virtual Food Food4 { get; set; }
        [ForeignKey(nameof(Food5Id))]
        [InverseProperty(nameof(Food.FoodRecommendationFood5s))]
        public virtual Food Food5 { get; set; }
        [ForeignKey(nameof(RestId))]
        [InverseProperty(nameof(Restaurant.FoodRecommendations))]
        public virtual Restaurant Rest { get; set; }
    }
}
