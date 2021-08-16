using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Foodilizer_Group35.Models
{
    [Table("order_with_payment")]
    public partial class OrderWithPayment
    {
        [Key]
        [Column("order_id")]
        public int OrderId { get; set; }
        [Column("payment_gateway_details")]
        public string PaymentGatewayDetails { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty(nameof(RestaurantOrder.OrderWithPayment))]
        public virtual RestaurantOrder Order { get; set; }
    }
}
