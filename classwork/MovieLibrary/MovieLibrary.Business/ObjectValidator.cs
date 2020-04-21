using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Business
{
    //Only cotain static members 
    //cannot create an instance 

    public static class ObjectValidator
    {
        //Global Functions 
        public static IEnumerable<ValidationResult> TryValidate (object value )
        {
            var errors = new List<ValidationResult>();

            Validator.TryValidateObject(value, new ValidationContext(value), errors, true);

            return errors;
        }

        public static void Validate (object value )
        {
            Validator.ValidateObject(value, new ValidationContext(value), true);
        }

       
    }
}
    