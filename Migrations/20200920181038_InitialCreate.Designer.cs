﻿// <auto-generated />
using ComicShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ComicShop.Migrations
{
    [DbContext(typeof(ComicContex))]
    [Migration("20200920181038_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ComicShop.Models.Comic", b =>
                {
                    b.Property<int>("ComicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ComicId");

                    b.ToTable("Comics");

                    b.HasData(
                        new
                        {
                            ComicId = 1,
                            Publisher = "DC",
                            Rating = 5,
                            Title = "Batman #608",
                            Year = 2019
                        },
                        new
                        {
                            ComicId = 2,
                            Publisher = "DC",
                            Rating = 5,
                            Title = "Superman Vs. Darkseid",
                            Year = 2015
                        },
                        new
                        {
                            ComicId = 3,
                            Publisher = "Image Comics",
                            Rating = 5,
                            Title = "Spawn #306",
                            Year = 2020
                        },
                        new
                        {
                            ComicId = 4,
                            Publisher = "Marvel",
                            Rating = 3,
                            Title = "The Tomb of Dracula",
                            Year = 1973
                        },
                        new
                        {
                            ComicId = 5,
                            Publisher = "Marvel",
                            Rating = 4,
                            Title = "True Believers #1 - Venom Carnage",
                            Year = 2019
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
