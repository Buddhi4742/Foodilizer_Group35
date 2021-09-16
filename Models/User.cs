using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
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
        [StringLength(100)]
        public string Password { get; set; }
        [Column("user_type")]
        [StringLength(100)]
        public string UserType { get; set; }

        public virtual CustomAccount CustomAccount { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public void ShaEnc()
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(Password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                Password = builder.ToString();
            }
        }
    }
}
