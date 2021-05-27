﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CMS.Data.ModelEntity
{
    public partial class AdvertisingBlock
    {
        [Key]
        public int Id { get; set; }
        public int? ArticleCategoryId { get; set; }
        public int? Position { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
        [StringLength(450)]
        public string CreateBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [StringLength(450)]
        public string LastEditedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastEditedDate { get; set; }
        public bool? IsMobile { get; set; }
    }
}