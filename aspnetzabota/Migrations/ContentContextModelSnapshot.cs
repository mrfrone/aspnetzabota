﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using aspnetzabota.Content.Database.Context;

namespace aspnetzabota.Web.Migrations
{
    [DbContext(typeof(ContentContext))]
    partial class ContentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("aspnetzabota.Content.Database.Entities.Articles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryID");

                    b.Property<DateTimeOffset>("Date");

                    b.Property<int?>("DepartmentId");

                    b.Property<string>("Description");

                    b.Property<string>("Img");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("aspnetzabota.Content.Database.Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasColumnName("categoryName");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("aspnetzabota.Content.Database.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartmentPriceID");

                    b.Property<string>("Description");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("aspnetzabota.Content.Database.Entities.DoctorInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("DoctorId");

                    b.Property<string>("Photo");

                    b.HasKey("Id");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("aspnetzabota.Content.Database.Entities.Licenses", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Licenses");
                });

            modelBuilder.Entity("aspnetzabota.Content.Database.Entities.LicensesPhoto", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LicensesId");

                    b.Property<string>("Path");

                    b.HasKey("Id");

                    b.HasIndex("LicensesId");

                    b.ToTable("LicensesPhoto");
                });

            modelBuilder.Entity("aspnetzabota.Content.Database.Entities.PriceArticles", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ArticleId");

                    b.Property<int?>("PriceId");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("PriceArticles");
                });

            modelBuilder.Entity("aspnetzabota.Content.Database.Entities.Review", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<DateTimeOffset>("Date");

                    b.Property<string>("Email");

                    b.Property<bool>("IsModerated");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("aspnetzabota.Content.Database.Entities.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Image");

                    b.HasKey("Id");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("aspnetzabota.Content.Database.Entities.Articles", b =>
                {
                    b.HasOne("aspnetzabota.Content.Database.Entities.Category", "Category")
                        .WithMany("news")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("aspnetzabota.Content.Database.Entities.Department")
                        .WithMany("Articles")
                        .HasForeignKey("DepartmentId");
                });

            modelBuilder.Entity("aspnetzabota.Content.Database.Entities.LicensesPhoto", b =>
                {
                    b.HasOne("aspnetzabota.Content.Database.Entities.Licenses")
                        .WithMany("Photo")
                        .HasForeignKey("LicensesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("aspnetzabota.Content.Database.Entities.PriceArticles", b =>
                {
                    b.HasOne("aspnetzabota.Content.Database.Entities.Articles", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId");
                });
#pragma warning restore 612, 618
        }
    }
}
