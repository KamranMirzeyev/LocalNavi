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
        public bool Status { get; set; }


        public string Title { get; set; }
        public string Slogan { get; set; }
        public int  CategoryId { get; set; }

        public string Website { get; set; }

       

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public string Facebook { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        
     
        public int CityId { get; set; }
      
        [Required]
        public int UserId { get; set; }  
       
        public string Lat { get; set; }
        public string Lng { get; set; }


        public Category Category { get; set; }
        public City City { get; set; }

        public User User { get; set; }

        public List<ListPhoto> ListPhotos { get; set; }
        public List<Photo> Photos { get; set; }
        public List<ListService> ListServices { get; set; }
        public  List<WorkHour> WorkHourses { get; set; }
        public  List<Comment> Comments { get; set; }


        

       
    }
}