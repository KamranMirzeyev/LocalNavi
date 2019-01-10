using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Navigation.Models
{
    public class Listing
    {
        public int  Id { get; set; }
        [Required]
        public bool Status { get; set; }

        [Required]
        public string Title { get; set; }
        public string Slogan { get; set; }
        [Required]
        public int  CategoryId { get; set; }
        [Required]
        public string Website { get; set; }


        [Required]
        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public string Facebook { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }

        [Required]
        public int CityId { get; set; }
      
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Lat { get; set; }
        [Required]
        public string Lng { get; set; }


        public Category Category { get; set; }
        public City City { get; set; }

        public User User { get; set; }

       
        public List<Photo> Photos { get; set; }
        public List<ListService> ListServices { get; set; }
        public  List<WorkHour> WorkHourses { get; set; }
        public  List<Comment> Comments { get; set; }


        

       
    }
}