//Carlos Vargas
//ITSE-1430
//Character Creator
//03/07/2020
//Character.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Bussiness
{
    public class Character
    {

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

        

        public bool Validate(out string error)
        {
            if (String.IsNullOrEmpty(Name))
            {
                error = "Character required.";
                return false;
            };

            if (String.IsNullOrEmpty(Description))
            {
                error = "Character required.";
                return false;
            };

            error = null;
            return true;
        }
    }
}
    
   

