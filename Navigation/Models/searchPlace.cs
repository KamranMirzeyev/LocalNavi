using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Navigation.Models
{
    public class searchPlace
    {
        public int id { get; set; }
        public string title { get; set; }
        public string slogan { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string city { get; set; }
        public string category { get; set; }
        public double? commentRat { get; set; }
        public string categoryIcon { get; set; }
        public List<WorkHour> hours { get; set; }
        public string photo { get; set; }
        public bool  status { get; set; }
        public int commentCount { get; set; }
    }
}