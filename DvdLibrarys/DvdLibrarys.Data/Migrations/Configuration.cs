namespace DvdLibrarys.Data.Migrations
{
    using DvdLibrarys.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DvdLibrarys.Data.DvdLibraryEntitites>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DvdLibrarys.Data.DvdLibraryEntitites context)
        {
            context.Dvd.AddOrUpdate(t => t.Title,

                new Dvd
                {
                    Title = "FaceOff",
                    ReleaseYear = 1997,
                    Rating = "PG",
                    DirectorName = "John Woo"
                },

                new Dvd
                {
                    Title = "Hitch",
                    ReleaseYear = 2005,
                    Rating = "R",
                    DirectorName = "Ali  Hirsi"

                },
                new Dvd
                {
                    Title = "Pulp Fiction",
                    ReleaseYear = 1997,
                    Rating = "PG",
                    DirectorName = "Quentin Tarantino"

                },
                new Dvd
                {
                    Title = "The Pursuit of Happiness",
                    ReleaseYear = 2006,
                    Rating = "P",
                    DirectorName = "Gabriele Muccino"
                },
                new Dvd
                {
                    Title = "Suburbicon",
                    ReleaseYear = 2017,
                    Rating = "PG-13",
                    DirectorName = "Matt Damon"
                },
                new Dvd
                {
                    Title = "Madia Goes To Jail",
                    ReleaseYear = 2014,
                    Rating = "R",
                    DirectorName = "Tyler Perry",
                }
                );
        }
    }
}
