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
        [StringLength(50)]
        public string PackageType { get; set; }
        [Column("registered_date")]
        [StringLength(10)]
        public string RegisteredDate { get; set; }
        [Column("rest_id")]
        public int? RestId { get; set; }
    }
}
