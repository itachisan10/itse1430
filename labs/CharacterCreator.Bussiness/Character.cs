//Carlos Vargas
//ITSE-1430
//Character Creator
//03/07/2020
//Character.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Bussiness
{
    public class Character : IValidatableObject
    {
        public int Id { get; set; }
        public Profession Profession { get; set; }
        public Race Race { get; set; }
        public Attribute Attribute { get; set; }
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value?.Trim(); }
        }
        private string _name;

        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim(); }
        }
        private string _description;

        public override string ToString () => Name;

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContect )
        {
            if (String.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name is required", new[] { nameof(Name) });
            }
            if (Profession == null)
            {
                yield return new ValidationResult("Professsion is required", new[] { nameof(Profession) });
            }
            if (Race == null)
            {
                yield return new ValidationResult("Race is required", new[] { nameof(Race) });
            }
          


        }

        
    }
}
    
   

