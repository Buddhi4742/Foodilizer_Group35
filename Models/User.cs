using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Foodilizer_Group35.Models
{
    [Table("user")]
    [Index(nameof(Email), Name = "email_UNIQUE", IsUnique = true)]
    public partial class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }
        [Required]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; }
        [Column("user_type")]
        [StringLength(50)]
        public string UserType { get; set; }

        public virtual CustomAccount Email1 { get; set; }
        public virtual Restaurant Email2 { get; set; }
        public virtual Customer EmailNavigation { get; set; }
    }
}
