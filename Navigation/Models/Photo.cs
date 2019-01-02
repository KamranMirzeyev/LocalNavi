using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Navigation.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public int ListingId { get; set; }
        public string PlacePhoto { get; set; }

        public Listing Listing { get; set; }
    }
}