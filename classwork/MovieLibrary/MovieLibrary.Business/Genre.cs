using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business
{
    public class Genre
    {
        public Genre(string descriptions)
        {
            Description = descriptions ?? "";
        }

        public string Description { get; }

        public override string ToString()
        {
            return Description;
        }
    }

    public class Genres
    {
        public static Genre[] GetAll()
        {
            var items = new Genre[5];
            items[0] = new Genre("Comedy");
            items[1] = new Genre("Action");
            items[2] = new Genre("Anime");
            items[3] = new Genre("Drama");
            items[4] = new Genre("Porn");
            return items;
        }
    }
}

