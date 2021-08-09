using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Foodilizer_Group35.Models
{
    [Keyless]
    [Table("sales_report")]
    public partial class SalesReport
    {
        [Column("report_id")]
        public int ReportId { get; set; }
        [Column("rest_id")]
        public int RestId { get; set; }
        [Column("date")]
        [StringLength(10)]
        public string Date { get; set; }
        [Column("content")]
        public string Content { get; set; }
    }
}
