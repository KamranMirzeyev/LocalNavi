using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Navigation.Models
{
    public class WorkHour
    {
        public int Id { get; set; }
        public int ListingId { get; set; }
        public int WeekNo { get; set; }
        public DateTime OpenHour { get; set; }
        public DateTime CloseHour { get; set; }

        public Listing Listing { get; set; }
    }
}