using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business
{
   public static class SeedDatabase
    {
        //this. creates an extension method 
        public static IMovieDatabase SeedIfEmpty ( this IMovieDatabase database )
        {
            if (!database.GetAll().Any()) 
            {
                //collection initiazer = works with anything with an add method
                var items = new Movie[] {
                    new Movie() { Title = "chicken little", RunLength = 210, ReleaseYear = 1997 },
                    new Movie() { Title = "space jams", RunLength = 210, ReleaseYear = 1997 },
                    new Movie() { Title = "jaws 2", RunLength = 210, ReleaseYear = 1997 },
                };

                foreach (var item in items)
                    database.Add(item);
            };
            return database;
        }
    }
}
