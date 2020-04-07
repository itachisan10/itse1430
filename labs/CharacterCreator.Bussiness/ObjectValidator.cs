//Carlos Vargas
//ITSE-1430
//Character Creator
//03/07/2020
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CharacterCreator.Bussiness
{
    public static class ObjectValidator
    {
        public static IEnumerable<ValidationResult> Validate (object value)
        {
            var errors = new List<ValidationResult>();
            Validator.TryValidateObject(value, new ValidationContext(value), errors, true);
            return errors;
        }
    }
}
