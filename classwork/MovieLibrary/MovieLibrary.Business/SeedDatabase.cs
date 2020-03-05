using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business
{
   public class SeedDatabase
    {
        public IMovieDatabase SeedIfEmpty (IMovieDatabase database )
        {
            if (database.GetAll().Length == 0) 
            {
                database.Add(new Movie() { Title = "chicken little", RunLength = 210, ReleaseYear = 1997 });
                database.Add(new Movie() { Title = "space jams", RunLength = 210, ReleaseYear = 1997 });
                database.Add(new Movie() { Title = "jaws 2", RunLength = 210, ReleaseYear = 1997 });
            };
            return database;
        }
    }
}
