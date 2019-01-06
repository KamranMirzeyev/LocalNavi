using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;

namespace Navigation.Models
{
    public class Reaction
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public byte Like { get; set; }

        public User User { get; set; }
        public Comment Comment { get; set; }


    }
}