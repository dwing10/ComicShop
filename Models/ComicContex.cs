using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicShop.Models
{
    public class ComicContex : DbContext
    {
        public ComicContex(DbContextOptions<ComicContex> options) : base(options)
        { }

        public DbSet<Comic> Comics { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Writer> Writers { get; set; }

        public DbSet<Artist> Artists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Writer>().HasData(
                new Writer { WriterID=1, WriterName="Jeph Loeb"},
                new Writer {WriterID = 2, WriterName = "John Byrne" },
                new Writer { WriterID = 3, WriterName = "Multiple"},
                new Writer { WriterID = 4, WriterName = "Todd McFarlane" },
                new Writer { WriterID = 5, WriterName = "Stan Lee" },
                new Writer { WriterID = 6, WriterName = "David Michelinie" });

            modelBuilder.Entity<Artist>().HasData(
                new Artist {ArtistID = 1, ArtistName = "Jim Lee" },
                new Artist {ArtistID = 2, ArtistName = "Alex Ross" },
                new Artist { ArtistID = 3, ArtistName = "Multiple" },
                new Artist { ArtistID = 4, ArtistName = "Philip Tan"},
                new Artist {ArtistID = 5, ArtistName = "Gene Colan" },
                new Artist { ArtistID = 6, ArtistName = "Mark Bagley" });

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher {PublisherID = 1, PublisherName = "Marvel Studios", City = "New York", State = "NY", Country = "US", PostalCode = "10001", Email = "OnlineSupport@marvel.com." },
                new Publisher { PublisherID = 2, PublisherName = "DC Comics", Address = "4000 Warner Boulevard", City = "Burbank", State = "CA", Country = "US", PostalCode = "91522", Phone = "818.954.4430" },
                new Publisher { PublisherID = 3, PublisherName = "Image Comics", City = "Portland", State = "OR", Country = "US", PostalCode = "97035" });

            modelBuilder.Entity<Comic>().HasData(
                new Comic
                {
                    ComicId = 1,
                    Title = "Batman #608",
                    WriterID = 1,
                    ArtistID = 1,
                    Year = 2019,
                    PublisherID = 2,
                    Rating = 5
                },
                new Comic
                { 
                    ComicId = 2,
                    Title = "Superman Vs. Darkseid",
                    WriterID = 2,
                    ArtistID = 3,
                    Year = 2015,
                    PublisherID = 2,
                    Rating = 5
                },
                new Comic
                {
                    ComicId = 3,
                    Title = "Spawn #306",
                    WriterID = 4,
                    ArtistID = 4,
                    Year = 2020,
                    PublisherID = 3,
                    Rating = 5
                },
                new Comic
                {
                    ComicId = 4,
                    Title = "The Tomb of Dracula",
                    WriterID = 5,
                    ArtistID = 5,
                    Year = 1973,
                    PublisherID = 1,
                    Rating = 3
                },
                new Comic
                {
                    ComicId = 5,
                    Title = "True Believers #1 - Venom Carnage",
                    WriterID = 6,
                    ArtistID = 6,
                    Year = 2019,
                    PublisherID = 1,
                    Rating = 4
                });
        }
    }
}
