﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CMS.Data
{
    public partial class CmsContext : DbContext
    {
      
        public CmsContext(DbContextOptions<CmsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Advertising> Advertising { get; set; }
        public virtual DbSet<AdvertisingBlock> AdvertisingBlock { get; set; }
        public virtual DbSet<AdvertisingBlockDetail> AdvertisingBlockDetail { get; set; }
        public virtual DbSet<AdvertisingMaping> AdvertisingMaping { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserProfiles> AspNetUserProfiles { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ReplaceChar> ReplaceChar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Advertising>(entity =>
            {
                entity.Property(e => e.AdvertisingId).HasColumnName("Advertising_ID");

                entity.Property(e => e.AdvertisingBlockId).HasColumnName("AdvertisingBlock_ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.FormId).HasMaxLength(50);

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.IsCode).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastEditDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(1000);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .HasColumnName("URL");

                entity.HasOne(d => d.AdvertisingBlock)
                    .WithMany(p => p.Advertising)
                    .HasForeignKey(d => d.AdvertisingBlockId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Advertising_AdvertisingBlock");
            });

            modelBuilder.Entity<AdvertisingBlock>(entity =>
            {
                entity.Property(e => e.AdvertisingBlockId).HasColumnName("AdvertisingBlock_ID");

                entity.Property(e => e.ArticleCategoryId).HasColumnName("ArticleCategory_ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.IsMobile).HasDefaultValueSql("((0))");

                entity.Property(e => e.JssorSlideId).HasColumnName("JssorSlide_ID");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.SizeSuggest).HasMaxLength(500);
            });

            modelBuilder.Entity<AdvertisingBlockDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<AdvertisingMaping>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateBy).HasMaxLength(200);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LastEditBy).HasMaxLength(200);

                entity.Property(e => e.LastEditDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.ConcurrencyStamp)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.NormalizedName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.ProviderDisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserProfiles>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.AvatarUrl).HasMaxLength(250);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Company).HasMaxLength(250);

                entity.Property(e => e.Department).HasMaxLength(500);

                entity.Property(e => e.DirectManagement).HasMaxLength(500);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FacebookId)
                    .HasMaxLength(50)
                    .HasColumnName("FacebookID");

                entity.Property(e => e.FormOfLabor).HasMaxLength(500);

                entity.Property(e => e.FullName).HasMaxLength(250);

                entity.Property(e => e.Gender).HasComment("true là nam, false là nữ");

                entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                entity.Property(e => e.LocationId).HasColumnName("Location_ID");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.ProductBrandId).HasColumnName("ProductBrand_ID");

                entity.Property(e => e.ReferralAccountCode).HasMaxLength(250);

                entity.Property(e => e.RegType)
                    .HasMaxLength(50)
                    .HasComment("1 là email, 2 là sdt");

                entity.Property(e => e.RegisterDate).HasColumnType("datetime");

                entity.Property(e => e.Signature).HasMaxLength(2000);

                entity.Property(e => e.Skype).HasMaxLength(250);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.VerifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Website).HasMaxLength(250);

                entity.Property(e => e.WorkPosition).HasMaxLength(500);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(190);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.AccountCode).HasMaxLength(500);

                entity.Property(e => e.ConcurrencyStamp)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.IsEnabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.LockoutEnd).HasColumnType("datetime");

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.NormalizedEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedUserName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasIndex(e => new { e.ProductCategoryId, e.ParentId }, "NonClusteredIndex-20190717-113259");

                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategory_ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Icon).HasMaxLength(500);

                entity.Property(e => e.Image).HasMaxLength(500);

                entity.Property(e => e.LanguageId).HasColumnName("Language_ID");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.MetaDescription).HasMaxLength(500);

                entity.Property(e => e.MetaKeywords).HasMaxLength(500);

                entity.Property(e => e.MetaTitle).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.ParentId).HasColumnName("Parent_ID");

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<ReplaceChar>(entity =>
            {
                entity.Property(e => e.ReplaceCharId).HasColumnName("ReplaceChar_ID");

                entity.Property(e => e.NewChar).HasMaxLength(1);

                entity.Property(e => e.OldChar).HasMaxLength(5);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}