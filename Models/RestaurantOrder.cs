using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Foodilizer_Group35.Models
{
    [Table("restaurant_order")]
    [Index(nameof(CustomerId), Name = "fk_custorder_idx")]
    [Index(nameof(RestId), Name = "fk_restau")]
    public partial class RestaurantOrder
    {
        public RestaurantOrder()
        {
            OrderIncludesFoods = new HashSet<OrderIncludesFood>();
        }

        [Key]
        [Column("order_id")]
        public int OrderId { get; set; }
        [Column("customer_id")]
        public int? CustomerId { get; set; }
        [Column("delivery_address")]
        public string DeliveryAddress { get; set; }
        [Column("content")]
        public string Content { get; set; }
        [Column("total_amount")]
        public int? TotalAmount { get; set; }
        [Column("date", TypeName = "datetime")]
        public DateTime? Date { get; set; }
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
        [InverseProperty(nameof(OrderIncludesFood.Order))]
        public virtual ICollection<OrderIncludesFood> OrderIncludesFoods { get; set; }
    }
}
