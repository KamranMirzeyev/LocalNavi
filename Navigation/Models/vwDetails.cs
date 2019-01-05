using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Navigation.Models
{
    public class vwDetails
    {
        public Listing Listing { get; set; }
        public List<ListService> ListServices { get; set; }
        public List<Comment> Comments { get; set; }
    }
}