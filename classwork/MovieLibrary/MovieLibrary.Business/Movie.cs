using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business
{
    /// <summary>Represents a movie.</summary>
    /// <remarks>
    /// Lots of info.
    /// </remarks>
    public class Movie : IValidatableObject 
    {
        public Genre Genre { get; set; }
        public int RunLength { get; set; }
        public int ReleaseYear { get; set; } = 1900;
        public bool IsClassic { get; set; }
        public int Id { get; set; }

        public string Title
        {
            //get{ return _title ?? ""; }
            get => _title ?? ""; // expression body 

            //set { _title = value?.Trim(); }
            set =>_title = value?.Trim(); //expression body 
        }
        private string _title;

        public string Description
        {
           // get { return _description ?? ""; }
            get => _description ?? ""; 
           // set { _description = value?.Trim(); }
            set =>_description = value?.Trim(); 
        }
        private string _description;

        public bool IsBlackAndWhite
        {
            // get { return ReleaseYear <= 1930; }
            get => ReleaseYear <= 1930; 
        }

        public override string ToString () => Title;
        //{
        //    return Title;
        //}

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            //Title is required
            //if (txtTitle.Text?.Trim() == "")
            if (String.IsNullOrEmpty(Title))
            {
                yield return new ValidationResult("Title is required.", new[] { nameof(Title)});
            };

            //Run length >= 0
            if (RunLength < 0)
            {
                yield return new ValidationResult("Run length must be >=0.", new[] {nameof(RunLength)});
            };

            //Release year >= 1900
            if (ReleaseYear < 1900)
            {
                yield return new ValidationResult("Release year must be >= 1900.", new[] { nameof(ReleaseYear)});
            };
        }
    }
}
