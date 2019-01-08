using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Navigation.Models
{
    public class HomeViewModel
    {
        public List<Category> category { get; set; }
        public List<Blog> Blogs { get; set; }

        public List<searchPlace> Places { get; set; }
        public List<vwCity> Listings { get; set; }
    }
}