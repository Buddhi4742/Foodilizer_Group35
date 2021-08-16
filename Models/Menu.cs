using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Foodilizer_Group35.Models
{
    [Table("menu")]
    [Index(nameof(RestId), Name = "fk_mr")]
    public partial class Menu
    {
        public Menu()
        {
            Foods = new HashSet<Food>();
        }

        [Key]
        [Column("menu_id")]
        public int MenuId { get; set; }
        [Column("rest_id")]
        public int? RestId { get; set; }

        [ForeignKey(nameof(RestId))]
        [InverseProperty(nameof(Restaurant.Menus))]
        public virtual Restaurant Rest { get; set; }
        [InverseProperty(nameof(Food.Menu))]
        public virtual ICollection<Food> Foods { get; set; }
    }
}
