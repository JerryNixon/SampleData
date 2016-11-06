using System;
using System.Collections.Generic;
using System.Linq;
using SampleData.StarTrek.Models.Xml;

namespace SampleData.StarTrek.Models
{
    public class Show
    {
        public Show(Xml.StarTrekShow show)
        {
            Name = show.Name;
            Image = show.Image;
            HeroImage = show.Hero;
            Characters = show.Character.Select(x => new Character(x));
            Code = (Codes)Enum.Parse(typeof(Codes), show.Code);
        }

        public string Name { get; set; }
        public string Image { get; set; }
        public string HeroImage { get; set; }
        public Codes Code { get; set; }
        public IEnumerable<Character> Characters { get; set; }
        public IEnumerable<Season> Seasons { get; set; }
    }
}