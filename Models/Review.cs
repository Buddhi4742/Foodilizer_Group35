using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Foodilizer_Group35.Models
{
    [Keyless]
    [Table("review")]
    public partial class Review
    {
        [Column("review_id")]
        public int ReviewId { get; set; }
        [Column("rating")]
        public int? Rating { get; set; }
        [Column("feedback")]
        [StringLength(200)]
        public string Feedback { get; set; }
        [Column("customer_id")]
        public int? CustomerId { get; set; }
        [Column("rest_id")]
        public int? RestId { get; set; }
        [Required]
        [Column("review_image")]
        [StringLength(200)]
        public string ReviewImage { get; set; }
        [Column("date", TypeName = "date")]
        public DateTime Date { get; set; }
    }
}
