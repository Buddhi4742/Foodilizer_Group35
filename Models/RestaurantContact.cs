using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Foodilizer_Group35.Models
{
    [Keyless]
    [Table("restaurant_contact")]
    public partial class RestaurantContact
    {
        [Column("rest_id")]
        public int RestId { get; set; }
        [Required]
        [Column("contact_number")]
        [StringLength(10)]
        public string ContactNumber { get; set; }
    }
}
