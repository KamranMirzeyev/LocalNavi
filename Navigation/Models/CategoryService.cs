using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Navigation.Models
{
    public class CategoryService
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public  int ServiceId { get; set; }

        public Category Category { get; set; }

        public  Service Service { get; set; }
    }
}