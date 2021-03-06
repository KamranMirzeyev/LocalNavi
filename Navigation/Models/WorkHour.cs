﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Navigation.Models
{
    public class WorkHour
    {
        public int Id { get; set; }
        public int ListingId { get; set; }
        public string WeekNo { get; set; }

     
        public TimeSpan OpenHour { get; set; }

       
        public TimeSpan CloseHour { get; set; }

        public Listing Listing { get; set; }
    }
}