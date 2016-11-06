using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleData.StarTrek.Models
{
    public class Season
    {
        public Season(string x)
        {
            Name = x;
            Number = int.Parse(x);
        }
        public string Name { get; set; }
        public int Number { get; set; }
        public IEnumerable<Episode> Episodes { get; set; }
    }
}
