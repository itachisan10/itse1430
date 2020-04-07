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
    public interface ICharacterRoster
    {
        Character Get ( int id );

        void Delete ( int id );

        Character Add ( Character character );

        string Update ( int id, Character character );

        IEnumerable<Character> GetAll ();
    }
}
