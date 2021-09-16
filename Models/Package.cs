using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Foodilizer_Group35.Models
{
    [Table("package")]
    [Index(nameof(RestId), Name = "fk_pckg")]
    public partial class Package
    {
        [Key]
        [Column("package_id")]
        public int PackageId { get; set; }
        [Column("package_type")]
        [StringLength(100)]
        public string PackageType { get; set; }
        [Column("registered_date", TypeName = "datetime")]
        public DateTime? RegisteredDate { get; set; }
        [Column("rest_id")]
        public int? RestId { get; set; }

        [ForeignKey(nameof(RestId))]
        [InverseProperty(nameof(Restaurant.Packages))]
        public virtual Restaurant Rest { get; set; }
    }
}
