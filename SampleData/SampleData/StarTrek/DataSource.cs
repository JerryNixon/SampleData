using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Windows.ApplicationModel;
using Windows.Storage;

namespace SampleData.StarTrek
{
    class DataSource
    {
        Models.Xml.StarTrek _cache;
        async Task<Models.Xml.StarTrek> GetCacheAsync()
        {
            if (_cache != null)
            {
                return _cache;
            }

            var name = "data.xml";
            var folder = await Package.Current.InstalledLocation.GetFolderAsync("StarTrek");
            var file = await folder.CreateFileAsync(name, CreationCollisionOption.OpenIfExists);
            if (file == null)
            {
                throw new FileNotFoundException(name);
            }

            var serializer = new DataContractSerializer(typeof(Models.Xml.StarTrek), new Type[] {
                typeof(Models.Xml.StarTrek),
                typeof(Models.Xml.Show),
                typeof(Models.Xml.Episode),
                typeof(Models.Xml.Character)
            });

            using (var stream = await file.OpenReadAsync())
            {
                var result = serializer.ReadObject(stream.AsStreamForRead());
                return _cache = result as Models.Xml.StarTrek;
            }
        }
    }
}
