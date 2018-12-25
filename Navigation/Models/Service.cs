using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Navigation.Models
{
    public class Service
    {
        public int Id { get; set; }
        public  string Name { get; set; }

        public List<ListService> ListServices { get;set; }
        public List<CategoryService> CategoryServices { get; set; }

    }
}