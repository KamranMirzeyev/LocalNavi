using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Navigation.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Boş buraxmayın")]
        public int Orderby { get; set; }

        public string BigPhoto { get; set; }
        public string SmallPhoto { get; set; }

        [Required(ErrorMessage = "Boş buraxmayın")]
        [MaxLength(250, ErrorMessage = "Max 250 simvol istifadə edə bilərsiniz!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Boş buraxmayın")]
        [Column(TypeName = "datetime")]
        public DateTime CreateAt { get; set; }

        [Required(ErrorMessage = "Boş buraxmayın")]
        [MaxLength(50, ErrorMessage = "Max 50 simvol istifadə edə bilərsiniz!")]
        public string BlogType { get; set; }

        [Required(ErrorMessage = "Boş buraxmayın")]
        [Column(TypeName = "ntext")]
        public string Info { get; set; }
    }
}