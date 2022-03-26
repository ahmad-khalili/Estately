using System;
using System.Collections.Generic;
using System.Text;

namespace Estately.Models
{
    public class Listing
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public List<string> Features { get; set; }
        public double Price { get; set; }
        public double Size { get; set; }
        public string Location { get; set; }
        public string Featured { get; set; }
    }
}
