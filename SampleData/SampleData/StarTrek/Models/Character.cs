using System;
using System.Collections.Generic;
using System.Linq;
using SampleData.StarTrek.Models.Xml;

namespace SampleData.StarTrek.Models
{
    public class Character
    {
        public Character(Xml.StarTrekShowCharacter character)
        {
            Name = character.Name;
            Actor = character.Actor;
            Image = character.Image;
        }

        public string Name { get; set; }
        public string Actor { get; set; }
        public string Image { get; set; }
    }
}