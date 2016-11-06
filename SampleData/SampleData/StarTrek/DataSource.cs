using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using SampleData.StarTrek.Models;
using Windows.ApplicationModel;
using Windows.Storage;

namespace SampleData.StarTrek
{
    public class DataSource
    {
        IEnumerable<Show> _shows;
        public async Task<IEnumerable<Show>> GetShowsAsync()
        {
            if (_shows != null)
            {
                return _shows;
            }
            var cache = await GetCacheAsync();
            _shows = cache.Show.Select(x => new Show(x));
            foreach (var show in _shows)
            {
                var episodes = cache.Episode
                    .Where(x => x.Code == show.Code.ToString())
                    .OrderBy(e => e.Ordinal);
                var seasons = episodes
                    .OrderBy(x => x.Season)
                    .Select(x => x.Season)
                    .Distinct()
                    .Select(x => new Season(x.ToString())
                    {
                        Episodes = episodes
                            .Where(e => e.Season == x)
                            .Select(e => new Episode(e))
                    });
                show.Seasons = seasons;
            }
            return _shows;
        }

        Models.Xml.StarTrek _cache;
        async Task<Models.Xml.StarTrek> GetCacheAsync()
        {
            if (_cache != null)
            {
                return _cache;
            }

            var serializer = new DataContractSerializer(typeof(Models.Xml.StarTrek), new Type[] {
                typeof(Models.Xml.StarTrek),
                typeof(Models.Xml.StarTrekShow),
                typeof(Models.Xml.StarTrekEpisode),
                typeof(Models.Xml.StarTrekShowCharacter)
            });

            var assembly = typeof(DataSource).GetTypeInfo().Assembly;
            var resource = $"{nameof(SampleData)}.{nameof(StarTrek)}.Data.xml";
            using (var stream = assembly.GetManifestResourceStream(resource))
            {
                using (var reader = XmlReader.Create(stream))
                {
                    // var xml = await reader.ReadToEndAsync();
                    var result = serializer.ReadObject(reader);
                    return _cache = result as Models.Xml.StarTrek;
                }
            }
        }
    }
}
