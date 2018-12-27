using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Navigation.Models
{
    public class PlaceViewModel
    {
        public List<Category> category { get; set; }
        public List<City> city { get; set; }
        public Listing  Listing { get; set; }
    }
}