using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Bussiness
{
    public class Attribute
    {
        public Attribute(string descriptions)
        {
            Description = descriptions ?? "";
        }

        public string Description { get; }

        public override string ToString()
        {
            return Description;
        }
    }

    public class Attributes
    {
        public static Attribute[] GetAll()
        {
            var items = new Attribute[5];
            items[0] = new Attribute("Strength");
            items[1] = new Attribute("Intelligence");
            items[2] = new Attribute("Aguility");
            items[3] = new Attribute("Constitution");
            items[4] = new Attribute("Charisma");
            return items;
        }
    }
}
