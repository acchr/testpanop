using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Panoptis.Models
{
    public class Item
    {

        public int id { get; set; }
        public String pubdate { get; set; }

        public String title { get; set; }
        public String image { get; set; }
        public String description { get; set; }
        public String category { get; set; }
        public String link { get; set; }
    }
}