﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aspnetzabota.Content.Database.Entities;

namespace aspnetzabota.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20191213082152_AddDeprtmentPriceID")]
    partial class AddDeprtmentPriceID
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099");

            modelBuilder.Entity("aspnetzabota.Data.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasColumnName("categoryName");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("aspnetzabota.Data.Models.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartmentPriceID");

                    b.Property<string>("Description");

                    b.Property<string>("IMG");

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("ID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("aspnetzabota.Data.Models.Licenses", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("Licenses");
                });

            modelBuilder.Entity("aspnetzabota.Data.Models.LicensesPhoto", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Licensesid");

                    b.Property<string>("path");

                    b.HasKey("id");

                    b.HasIndex("Licensesid");

                    b.ToTable("LicensesPhoto");
                });

            modelBuilder.Entity("aspnetzabota.Data.Models.News", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date")
                        .HasColumnName("newsDate");

                    b.Property<string>("Decription")
                        .HasColumnName("newsDecription");

                    b.Property<string>("IMG")
                        .HasColumnName("newsIMG");

                    b.Property<string>("Name")
                        .HasColumnName("newsName");

                    b.Property<int>("categoryID");

                    b.HasKey("ID");

                    b.HasIndex("categoryID");

                    b.ToTable("News");
                });

            modelBuilder.Entity("aspnetzabota.Data.Models.Review", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("author");

                    b.Property<string>("date");

                    b.Property<string>("email");

                    b.Property<string>("text");

                    b.HasKey("id");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("aspnetzabota.Data.Models.Slider", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<string>("image");

                    b.Property<string>("postTitle");

                    b.Property<string>("title");

                    b.HasKey("ID");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("aspnetzabota.Data.Models.LicensesPhoto", b =>
                {
                    b.HasOne("aspnetzabota.Data.Models.Licenses")
                        .WithMany("photo")
                        .HasForeignKey("Licensesid");
                });

            modelBuilder.Entity("aspnetzabota.Data.Models.News", b =>
                {
                    b.HasOne("aspnetzabota.Data.Models.Category", "Category")
                        .WithMany("news")
                        .HasForeignKey("categoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
