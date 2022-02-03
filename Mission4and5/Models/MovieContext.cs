using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Mission4and5.Models
{
    public class MovieContext : DbContext 
    {
        // Constructor
        public MovieContext (DbContextOptions<MovieContext> options) : base(options)
        {
            // Leave blank for now
        }
        public DbSet<MovieEntry> entries { get; set; }
        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(

                new Category { CategoryID = 1, CategoryName = "Action/Adventure"},
                new Category { CategoryID = 2, CategoryName = "Comedy" },
                new Category { CategoryID = 3, CategoryName = "Drama" },
                new Category { CategoryID = 4, CategoryName = "Family" },
                new Category { CategoryID = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryID = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryID = 7, CategoryName = "Television" },
                new Category { CategoryID = 8, CategoryName = "VHS" }

                );
            mb.Entity<MovieEntry>().HasData(

                new MovieEntry
                {
                    MovieID = 1,
                    CategoryID = 1,
                    Title = "Avengers, The",
                    Year = 2012,
                    Director = "Joss Whedon",
                    Rating = "PG-13"
                },
                new MovieEntry
                {
                    MovieID = 2,
                    CategoryID = 1,
                    Title = "Batman",
                    Year = 1989,
                    Director = "Tim Burton",
                    Rating = "PG-13"
                },
                new MovieEntry
                {
                    MovieID = 3,
                    CategoryID = 1,
                    Title = "Batman & Robin",
                    Year = 1997,
                    Director = "Joel Schumacher",
                    Rating = "PG-13"
                }

             );
        }
    }
}
