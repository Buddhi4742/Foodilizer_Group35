using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Foodilizer_Group35.Models
{
    [Table("restaurant_order")]
    [Index(nameof(CustomerId), Name = "fk_cust")]
    [Index(nameof(RestId), Name = "fk_restau")]
    public partial class RestaurantOrder
    {
        [Key]
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

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("RestaurantOrders")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(RestId))]
        [InverseProperty(nameof(Restaurant.RestaurantOrders))]
        public virtual Restaurant Rest { get; set; }
        [InverseProperty("Order")]
        public virtual OrderWithPayment OrderWithPayment { get; set; }
    }
}
