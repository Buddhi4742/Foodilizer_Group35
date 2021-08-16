using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Foodilizer_Group35.Models
{
    [Table("item")]
    [Index(nameof(RestId), Name = "fk_restit")]
    public partial class Item
    {
        [Column("rest_id")]
        public int? RestId { get; set; }
        [Key]
        [Column("item_id")]
        public int ItemId { get; set; }
        [Column("item_name")]
        [StringLength(50)]
        public string ItemName { get; set; }
        [Column("item_quantity")]
        public decimal? ItemQuantity { get; set; }
        [Required]
        [Column("measurement")]
        [StringLength(50)]
        public string Measurement { get; set; }
        [Column("quantity_limit")]
        public decimal? QuantityLimit { get; set; }
        [Column("alert")]
        [StringLength(50)]
        public string Alert { get; set; }

        [ForeignKey(nameof(RestId))]
        [InverseProperty(nameof(Restaurant.Items))]
        public virtual Restaurant Rest { get; set; }
    }
}
