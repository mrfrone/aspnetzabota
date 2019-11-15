﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aspnetzabota.Data;

namespace aspnetzabota.Migrations
{
    [DbContext(typeof(AppDBContent))]
    [Migration("20191024134246_AddSlider")]
    partial class AddSlider
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

                    b.Property<string>("categoryName");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("aspnetzabota.Data.Models.News", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("categoryID");

                    b.Property<DateTime>("newsDate");

                    b.Property<string>("newsDecription");

                    b.Property<string>("newsIMG");

                    b.Property<string>("newsName");

                    b.HasKey("ID");

                    b.HasIndex("categoryID");

                    b.ToTable("News");
                });

            modelBuilder.Entity("aspnetzabota.Data.Models.Slider", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<string>("title");

                    b.HasKey("ID");

                    b.ToTable("Sliders");
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
