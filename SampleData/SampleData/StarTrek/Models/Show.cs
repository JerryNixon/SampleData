using System;
using System.Collections.Generic;
using System.Linq;

namespace SharedCode.Common.Models
{
    public class Show
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Hero { get; set; }
        public Character[] Characters { get; set; }
        public Codes Code { get; set; }
    }
}