using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business
{
    public class Movie
    {

        /// <summary>
        /// Represents a movie.
        /// </summary>

        // all members are private, only Movie has access.. can be changed by using public Ex: [[public string title;]]
        public string title;

        /// <summary>
        /// Run length in minutes. 
        /// </summary>
        public int runLength;
        public string description;
        public int releaseYear = 1990;
        public bool isClassic;

        //fields -> data 
       

        
    }
}
