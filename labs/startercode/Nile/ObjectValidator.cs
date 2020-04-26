/*
 * Carlos Vargas
 * April 25, 2020
 * ITSE 1430
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nile
{
    class ObjectValidator
    {
        public static IEnumerable<ValidationResult> TryValidate(object value)
        {

            var errors = new List<ValidationResult>();

            Validator.TryValidateObject(value, new ValidationContext(value), errors, true);

            return errors;
        }

       //// public static void Validate(object value)
       // {
       //     Validator.ValidateObject(value, new ValidationContext(value), true);
       // }
    }
}
