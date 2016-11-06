using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleData.StarTrek.Models.Xml;

namespace SampleData.StarTrek.Models
{
    public class Episode
    {
        public Episode(Xml.StarTrekEpisode episode)
        {
            Ordinal = episode.Ordinal.ToString();
            Season = episode.Season.ToString();
            Number = episode.Episode.ToString();
            Stardate = episode.Stardate;
            Title = episode.Title;
        }

        public string Nickname => $"S{Season:00}E{Number:00}";
        public string Number { get; set; }
        public string Season { get; set; }
        public string Ordinal { get; set; }
        public string Stardate { get; set; }
        public string Title { get; set; }
    }
}
