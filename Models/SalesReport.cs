using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Foodilizer_Group35.Models
{
    [Table("sales_report")]
    [Index(nameof(RestId), Name = "fk_rests")]
    public partial class SalesReport
    {
        [Key]
        [Column("report_id")]
        public int ReportId { get; set; }
        [Column("rest_id")]
        public int RestId { get; set; }
        [Column("date")]
        [StringLength(10)]
        public string Date { get; set; }
        [Column("content")]
        public string Content { get; set; }

        [ForeignKey(nameof(RestId))]
        [InverseProperty(nameof(Restaurant.SalesReports))]
        public virtual Restaurant Rest { get; set; }
    }
}
