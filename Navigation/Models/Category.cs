using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Navigation.Models
{
    public class Category
    {
        [Key]
       public  int Id { get; set; }
       
        [Required]
        public string Name { get; set; }

        public string Icon { get; set; }

        private List<Listing> Listings { get; set; }
    }
}