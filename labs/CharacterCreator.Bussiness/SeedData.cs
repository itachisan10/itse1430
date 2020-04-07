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
    public static class SeedData
    {
        public static ICharacterRoster SeedIfEmpty ( this ICharacterRoster database )
        {
            if (!database.GetAll().Any())
            {
                var example = new Character() { Name = "Itachi", Description = "Ninja"};
                var items = new[] {
                    new Character() {Name = "Sasuke", Description = "Ninja"},
                    new Character() {Name = "Naruto", Description = "Ninja"}
                  };
               foreach (var item in items)
                database.Add(item);
             };
               return database;
       } 
    }
}