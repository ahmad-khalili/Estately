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
        public string Feature1 { get; set; }
        public string Feature2 { get; set; }
        public string Feature3 { get; set; }
        public string Feature4 { get; set; }
        public double Price { get; set; }
        public double Size { get; set; }
        public string Location { get; set; }
        public string Featured { get; set; }
        public string Image { get; set; }
    }
}
