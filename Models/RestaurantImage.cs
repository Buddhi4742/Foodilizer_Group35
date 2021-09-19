using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Foodilizer_Group35.Models
{
    [Table("restaurant_image")]
    public partial class RestaurantImage
    {
        [Key]
        [Column("rest_id")]
        public int RestId { get; set; }
        [Column("main_image_path")]
        [StringLength(2000)]
        public string MainImagePath { get; set; }
        [Column("banner_image_path")]
        [StringLength(2000)]
        public string BannerImagePath { get; set; }
        [Column("gallery_image_1_path")]
        [StringLength(2000)]
        public string GalleryImage1Path { get; set; }
        [Column("gallery_image_2_path")]
        [StringLength(2000)]
        public string GalleryImage2Path { get; set; }
        [Column("gallery_image_3_path")]
        [StringLength(2000)]
        public string GalleryImage3Path { get; set; }
        [Column("gallery_image_4_path")]
        [StringLength(2000)]
        public string GalleryImage4Path { get; set; }
        [Column("gallery_image_5_path")]
        [StringLength(2000)]
        public string GalleryImage5Path { get; set; }

        [ForeignKey(nameof(RestId))]
        [InverseProperty(nameof(Restaurant.RestaurantImage))]
        public virtual Restaurant Rest { get; set; }
    }
}
