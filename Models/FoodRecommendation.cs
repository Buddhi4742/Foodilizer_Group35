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
    }
}
