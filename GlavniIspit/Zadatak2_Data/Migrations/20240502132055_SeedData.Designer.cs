﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zadatak2_Data.Data;

#nullable disable

namespace Zadatak2_Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240502132055_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Zadatak2_Data.Models.TodoList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TodoList");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Operi pod",
                            IsCompleted = true,
                            Title = "WC"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Operi WC školjku",
                            IsCompleted = false,
                            Title = "WC"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Operi pod",
                            IsCompleted = false,
                            Title = "Kuhinja"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}