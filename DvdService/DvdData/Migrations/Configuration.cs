namespace DvdData.Migrations
{
    using DvdModels.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DvdData.DvdLibraryEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DvdData.DvdLibraryEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Dvds.AddOrUpdate(
                d => d.Title,
                new Dvd
                {
                    Title = "Good Burger",
                    Rating = "G",
                    ReleaseYear = 1997,
                    Director = "Brian Robbins",
                    Notes = "Classic movie (orange VHS)"
                },
                new Dvd
                {
                    Title = "The Impossible Kid",
                    ReleaseYear = 1982,
                    Rating = "NR",
                    Director = "Eddie Nicart",
                    Notes = "Weng Weng is a superstar",
                },
                new Dvd
                {
                    Title = "Logan's Run",
                    ReleaseYear = 1976,
                    Rating = "PG",
                    Director = "Michael Anderson",
                    Notes = null,
                },
                new Dvd
                {
                    Title = "Blue Velvet",
                    ReleaseYear = 1986,
                    Rating = "R",
                    Director = "David Lynch",
                    Notes = "A David Lynch movie you can safetly recommend without lengthy explination",
                },
                new Dvd
                {
                    Title = "The Life Aquatic With Steve Zissou",
                    ReleaseYear = 2004,
                    Rating = "R",
                    Director = "Wes Anderson",
                    Notes = "Best Wes IMO",
                },
                new Dvd
                {
                    Title = "Rush Hour 3",
                    ReleaseYear = 2007,
                    Rating = "PG-13",
                    Director = "Brett Ratner",
                    Notes = "A modern Abbot an Costello duo",
                },
                new Dvd
                {
                    Title = "Eraserhead",
                    ReleaseYear = 1977,
                    Rating = "NR",
                    Director = "David Lynch",
                    Notes = "Good background image movie for a halloween party",
                },
                new Dvd
                {
                    Title = "Wake In Fright",
                    ReleaseYear = 1971,
                    Rating = "R",
                    Director = "Tes Kotcheff",
                    Notes = "Warning: A bunch of kangaroos get shot",
                },
                new Dvd
                {
                    Title = "El Topo",
                    ReleaseYear = 1970,
                    Rating = "NR",
                    Director = "Alejandro Jodorowski",
                    Notes = "A Jodorowski film you could watch with an artsy date",
                },
                new Dvd
                {
                    Title = "Toy Story",
                    ReleaseYear = 1995,
                    Rating = "G",
                    Director = "John Lasseter",
                    Notes = null,
                },
                new Dvd
                {
                    Title = "The Mist",
                    ReleaseYear = 2007,
                    Rating = "R",
                    Director = "Frank Darabont",
                    Notes = "The black and white version is the best version",
                }
                );
        }
    }
}
