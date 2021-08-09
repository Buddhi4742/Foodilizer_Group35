using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Foodilizer_Group35.Models
{
    [Table("order_includes_food")]
    public partial class OrderIncludesFood
    {
        [Key]
        [Column("order_id")]
        public int OrderId { get; set; }
        [Key]
        [Column("food_id")]
        public int FoodId { get; set; }
    }
}
