using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Navigation.Models
{
    public class ListPhoto
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public string Photo { get; set; }

        public Listing Listing { get; set; }
    }
}