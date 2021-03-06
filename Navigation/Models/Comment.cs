﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Navigation.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int ListingId { get; set; }
        public int UserId { get; set; }
        public byte Rating { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }


        public User User { get; set; }
        public Listing Listing { get; set; }
        public  List<Reaction> Reactions { get; set; }
        public  List<CommentPhoto> CommentPhotos { get; set; }
    }
}