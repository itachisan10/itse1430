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
        public string Title // public 
        {
            get {   //long long way.    // get() T  if string, parameter must return string 
                //if (_title == null)
                //    return "";
                //return _title;

                //long way 
                //return (_title != null) ? _title : "";

                //CORECT WAY
                return _title ??"";
            }
            set { _title = value?.Trim(); } // set (T value) returns nothing 
        }
        private string _title; //private

        //public int RunLength
        //{
        //    get { return _runLength; }            
        //    set { _runLength = value; }
        //}
        //private int _runLength;

        public int RunLength { get; set; }

        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim(); }
        }
        private string _description;

        //public int ReleaseYear
        //{
        //    get { return _releaseYear; }
        //    set { _releaseYear = value; }
        //}
        //private int _releaseYear = 1990;
        public int ReleaseYear { get; set; } = 1900;

        //public bool IsClassic
        //{
        //    get { return _isClassic; }
        //    set { _isClassic = value; }
        //}
        //private bool _isClassic;
        public bool IsClassic { get; set; }
        //fields -> data 

        public bool IsBlackAndWhite
        {
            get { return ReleaseYear <= 1930; }
        }

        //public int Id
        //{
        //    get { return _id; }
        //   private set { _id = value; }
        //}
        //private int _id;
        public int Id { get; }


        public bool Validate(out string error)
        {
            //Tittle is required
            //if(txtTitle.Text?.Trim() == "")
            if (String.IsNullOrEmpty(Title))
            {
                error = "Title is required.";
                return false;
            };
            //Run length >= 0
            if (RunLength < 0)
            {

                error = "Run length must be >= 0.";
                return false;
            };
            //Release year >= 1900
            if (ReleaseYear < 1900)
            {

                error = "Release year must be >= 1900.";
                return false;
            };
            //if everything returns true then it will go thru
            error = null;
            return true;
        }



    }
}
