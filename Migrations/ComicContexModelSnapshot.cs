﻿// <auto-generated />
using ComicShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ComicShop.Migrations
{
    [DbContext(typeof(ComicContex))]
    partial class ComicContexModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ComicShop.Models.Comic", b =>
                {
                    b.Property<int>("ComicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PublisherID")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ComicId");

                    b.HasIndex("PublisherID");

                    b.ToTable("Comics");

                    b.HasData(
                        new
                        {
                            ComicId = 1,
                            PublisherID = 2,
                            Rating = 5,
                            Title = "Batman #608",
                            Year = 2019
                        },
                        new
                        {
                            ComicId = 2,
                            PublisherID = 2,
                            Rating = 5,
                            Title = "Superman Vs. Darkseid",
                            Year = 2015
                        },
                        new
                        {
                            ComicId = 3,
                            PublisherID = 3,
                            Rating = 5,
                            Title = "Spawn #306",
                            Year = 2020
                        },
                        new
                        {
                            ComicId = 4,
                            PublisherID = 1,
                            Rating = 3,
                            Title = "The Tomb of Dracula",
                            Year = 1973
                        },
                        new
                        {
                            ComicId = 5,
                            PublisherID = 1,
                            Rating = 4,
                            Title = "True Believers #1 - Venom Carnage",
                            Year = 2019
                        });
                });

            modelBuilder.Entity("ComicShop.Models.Publisher", b =>
                {
                    b.Property<int>("PublisherID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnName("Zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublisherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.HasKey("PublisherID");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            PublisherID = 1,
                            City = "New York",
                            Email = "OnlineSupport@marvel.com.",
                            PublisherName = "Marvel Studios",
                            State = "NY"
                        },
                        new
                        {
                            PublisherID = 2,
                            Address = "4000 Warner Boulevard",
                            City = "Burbank",
                            Phone = "818.954.4430",
                            PublisherName = "DC Comics",
                            State = "CA"
                        },
                        new
                        {
                            PublisherID = 3,
                            City = "Portland",
                            PublisherName = "Image Comics",
                            State = "OR"
                        });
                });

            modelBuilder.Entity("ComicShop.Models.Comic", b =>
                {
                    b.HasOne("ComicShop.Models.Publisher", "PublisherClass")
                        .WithMany()
                        .HasForeignKey("PublisherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
