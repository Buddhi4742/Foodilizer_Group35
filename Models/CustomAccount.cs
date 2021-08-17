using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Foodilizer_Group35.Models
{
    [Table("custom_account")]
    [Index(nameof(RestId), Name = "fk_custom")]
    [Index(nameof(Email), Name = "idx_custom_account_email", IsUnique = true)]
    [Index(nameof(Username), Name = "username", IsUnique = true)]
    public partial class CustomAccount
    {
        [Key]
        [Column("account_id")]
        public int AccountId { get; set; }
        [Column("account_title")]
        [StringLength(50)]
        public string AccountTitle { get; set; }
        [Column("account_status")]
        [StringLength(50)]
        public string AccountStatus { get; set; }
        [Required]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("username")]
        [StringLength(50)]
        public string Username { get; set; }
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; }
        [Column("rest_id")]
        public int RestId { get; set; }

        [ForeignKey(nameof(RestId))]
        [InverseProperty(nameof(Restaurant.CustomAccounts))]
        public virtual Restaurant Rest { get; set; }
        public virtual User User { get; set; }
    }
}
