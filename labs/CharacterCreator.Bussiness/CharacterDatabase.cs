//Carlos Vargas
//ITSE-1430
//Character Creator
//03/07/2020
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Bussiness
{
     public abstract class CharacterDatabase
    {

        
        public Character Get (int id )
        {
            if (id <= 0)
                return null;
            return GetCore(id);
        }
        protected abstract Character GetCore ( int id ); 
        
        public void Delete (int id )
        {
            if (id <= 0)
                return;
            DeleteCore(id);
        }

        protected abstract void DeleteCore ( int id );

        public Character Add (Character character )
        {
            //validate
            if (character == null)
                return null;
            //.net validation
            var errors = ObjectValidator.Validate(character);
            if (errors.Any())
                return null;
            //clone character to store
            var item = FindByName(character.Name);
            if (item != null)
                return null;

            return AddCore(character);
        }
        protected abstract Character AddCore ( Character character );

        public string Update ( int id, Character character )
        {
            //validate
            if (character == null)
                return "Character is invalid";

            var errors = ObjectValidator.Validate(character);
            if (errors.Any())
                return "Error";

            if (id <= 0)
                return "Id is invalid";

            var existing = FindById(id);
            if (existing == null)
                return "character cannot be found or invalid";

            //unique
            var sameName = FindByName(character.Name);
            if (sameName != null && sameName.Id != id)
                return "character must be unique";

            UpdateCore(id, character);

            return null;
        }

        protected abstract void UpdateCore ( int id, Character character );

        protected abstract Character FindByName ( string name );

        protected abstract Character FindById ( int id );

        public IEnumerable<Character> GetAll() => GetAllCore() ?? Enumerable.Empty<Character>();
        protected abstract IEnumerable<Character> GetAllCore ();

      
    }
}
