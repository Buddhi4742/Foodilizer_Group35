using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Foodilizer_Group35.Models
{
    [Table("order_includes_food")]
    [Index(nameof(FoodId), Name = "fk_foodorder_idx")]
    public partial class OrderIncludesFood
    {
        [Key]
        [Column("order_id")]
        public int OrderId { get; set; }
        [Key]
        [Column("food_id")]
        public int FoodId { get; set; }
        [Column("qty")]
        public int? QTY { get; set; }

        [ForeignKey(nameof(FoodId))]
        [InverseProperty("OrderIncludesFoods")]
        public virtual Food Food { get; set; }
        [ForeignKey(nameof(OrderId))]
        [InverseProperty(nameof(RestaurantOrder.OrderIncludesFoods))]
        public virtual RestaurantOrder Order { get; set; }
    }
}
