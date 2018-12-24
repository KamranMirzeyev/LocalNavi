using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Navigation.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public bool Status { get; set; }

        [Required(ErrorMessage = "Boş buraxmayın")]
        [MaxLength(50,ErrorMessage = "Maxsimum 50 simvol istifadə edə bilərsiniz")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Boş buraxmayın")]
        [MaxLength(50, ErrorMessage = "Maxsimum 50 simvol istifadə edə bilərsiniz")]
        [EmailAddress(ErrorMessage = "Düzgün email yazın!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Boş buraxmayın")]
        [MinLength(3,ErrorMessage = "Minimum 3 simvol daxil etməlisiniz")]
        public string Password { get; set; }
        public string Photo { get; set; }

    }
}