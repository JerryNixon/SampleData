using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleData.StarTrek.Models.Xml
{
    [XmlRoot(ElementName = "Character")]
    public class Character
    {
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "Actor")]
        public string Actor { get; set; }
        [XmlAttribute(AttributeName = "Image")]
        public string Image { get; set; }
    }

    [XmlRoot(ElementName = "Show")]
    public class Show
    {
        [XmlElement(ElementName = "Character")]
        public List<Character> Character { get; set; }
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "Hero")]
        public string Hero { get; set; }
        [XmlAttribute(AttributeName = "Image")]
        public string Image { get; set; }
        [XmlAttribute(AttributeName = "Code")]
        public string Code { get; set; }
    }

    [XmlRoot(ElementName = "Episode")]
    public class Episode
    {
        [XmlAttribute(AttributeName = "Code")]
        public string Code { get; set; }
        [XmlAttribute(AttributeName = "Season")]
        public string Season { get; set; }
        [XmlAttribute(AttributeName = "Episode")]
        public string _Episode { get; set; }
        [XmlAttribute(AttributeName = "Ordinal")]
        public string Ordinal { get; set; }
        [XmlAttribute(AttributeName = "Title")]
        public string Title { get; set; }
        [XmlAttribute(AttributeName = "Stardate")]
        public string Stardate { get; set; }
    }

    [XmlRoot(ElementName = "StarTrek")]
    public class StarTrek
    {
        [XmlElement(ElementName = "Show")]
        public List<Show> Show { get; set; }
        [XmlElement(ElementName = "Episode")]
        public List<Episode> Episode { get; set; }
    }

}
