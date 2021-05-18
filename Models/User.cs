using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class User
    {
        //Wyjdzie kiedyś jakieś wyrażenia regularne wykorzystać
        public int id { get; set; }
        [Display(Name = "Imię")]
        [MinLength(2)]
        public string firstName { get; set; }
        [Display(Name = "Nazwisko")]
        [MinLength(2)]
        public string lastName { get; set; }
        [Display(Name = "Data urodzenia")]
        [DataType(DataType.Date)]
        public string birthDate { get; set; }
        [Display(Name = "Nazwa użytkownika")]
        [Required(ErrorMessage = "Pole 'Nazwa użytkownika' jest wymagane")]
        public string nickname { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Pole 'E-mail' jest wymagane")]
        public string email { get; set; }
        [Display(Name = "Nr telefonu")]
        [MinLength(7)]
        public Int64 phone { get; set; }
    }
}
