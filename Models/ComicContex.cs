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

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Comic>().HasData(
                new Comic
                {
                    ComicId = 1,
                    Title = "Batman #608",
                    Year = 2019,
                    Publisher = "DC",
                    Rating = 5
                },
                new Comic
                { 
                    ComicId = 2,
                    Title = "Superman Vs. Darkseid",
                    Year = 2015,
                    Publisher = "DC",
                    Rating = 5
                },
                new Comic
                {
                    ComicId = 3,
                    Title = "Spawn #306",
                    Year = 2020,
                    Publisher = "Image Comics",
                    Rating = 5
                },
                new Comic
                {
                    ComicId = 4,
                    Title = "The Tomb of Dracula",
                    Year = 1973,
                    Publisher = "Marvel",
                    Rating = 3
                },
                new Comic
                {
                    ComicId = 5,
                    Title = "True Believers #1 - Venom Carnage",
                    Year = 2019,
                    Publisher = "Marvel",
                    Rating = 4
                });
        }
    }
}
