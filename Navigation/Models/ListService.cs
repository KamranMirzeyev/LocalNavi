using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Navigation.Models
{
    public class ListService
    {
        public int Id { get; set; }
        public int ListingId { get; set; }

        public int ServiceId { get; set; }

        public Listing Listing { get; set; }
        public Service Service { get; set; }
    }
}