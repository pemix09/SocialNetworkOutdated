using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class User
    {
        //Wyjdzie kiedyś jakieś wyrażenia regularne wykorzystać
        [Key]
        public int ID { get; set; }
        [Display(Name = "Imię")]
        [MinLength(2)]
        [DataType(DataType.Text)]
        public string firstName { get; set; }
        [Display(Name = "Nazwisko")]
        [MinLength(2)]
        [DataType(DataType.Text)]
        public string lastName { get; set; }
        [Display(Name = "Data urodzenia")]
        [DataType(DataType.Date)]
        public string birthDate { get; set; }
        [Display(Name = "Nazwa użytkownika")]
        [Required(ErrorMessage = "Pole 'Nazwa użytkownika' jest wymagane")]
        [DataType(DataType.Text)]
        public string nickname { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Pole 'E-mail' jest wymagane")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Display(Name = "Nr telefonu")]
        [MinLength(7)]
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
