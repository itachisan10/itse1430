using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Bussiness.Memory
{
   public class MemoryCharacterDatabase : CharacterDatabase
    {
        private Character CloneCharacter(Character character )
        {
            var item = new Character();
            CopyCharacter(item, character, true);
            return item;
        }

        private void CopyCharacter (Character target, Character source, bool includeId )
        {
            if (includeId)
                target.Id = source.Id;
            target.Name = source.Name;
            target.Description= source.Description;

            //profession
            if (source.Profession != null)
                target.Profession = new Profession(source.Profession.Description);
            else
                target.Profession = null;

            //race
            if (source.Race != null)
                target.Race = new Race(source.Race.Description);
            else
                target.Race = null;
        }

        protected override Character AddCore ( Character character )
        {
            var item = CloneCharacter(character);
           // item.Id = _id++;
            _character.Add(item);

            return CloneCharacter(item);
        }

        protected override Character GetCore ( int id )
        {
            var character = FindById(id);
            if (character == null)
                return null;

            return CloneCharacter(character);
        }
        protected override void DeleteCore ( int id )
        {
            var character = FindById(id);
            if (character != null)
                _character.Remove(character);
        }

        protected override IEnumerable<Character> GetAllCore()

        {
            var items = _character.Where(c => true);

            return _character.Select(c => CloneCharacter(c));
        }

        protected override void UpdateCore ( int id, Character character )
        {
            var item = FindById(id);
            CopyCharacter(item, character, false);
        }

        protected override Character FindByName ( string name ) => (from character in _character
                                                                    where String.Compare(character.Name, name, true)==0
                                                                    select character).FirstOrDefault();
        protected override Character FindById ( int id ) => _character.FirstOrDefault(c => c.Id == id);

        private readonly List<Character> _character = new List<Character>();
     
    }
}
