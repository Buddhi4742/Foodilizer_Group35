using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Foodilizer_Group35.Models
{
    [Keyless]
    [Table("restaurant_order")]
    public partial class RestaurantOrder
    {
        [Column("order_id")]
        public int OrderId { get; set; }
        [Column("customer_id")]
        public int? CustomerId { get; set; }
        [Column("delivery_address")]
        [StringLength(200)]
        public string DeliveryAddress { get; set; }
        [Column("content")]
        [StringLength(50)]
        public string Content { get; set; }
        [Column("total_amount")]
        public decimal? TotalAmount { get; set; }
        [Column("time")]
        [StringLength(16)]
        public string Time { get; set; }
        [Column("date")]
        [StringLength(10)]
        public string Date { get; set; }
        [Column("rest_id")]
        public int RestId { get; set; }
    }
}
