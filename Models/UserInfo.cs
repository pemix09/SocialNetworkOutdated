using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class UserInfo
    {
       /* public enum Gender
        {
            male, female
        }*/
        //Wyjdzie kiedyś jakieś wyrażenia regularne wykorzystać
        [Key]
        public int ID { get; set; }
        //trzeba bedzie usunac pewne pola zmieniajac wiekszosc na identity
        //stringID będzie od razu przypisywane przy tworzeniu konta użytkownika
        public string stringID { get; set; }
        [Display(Name = "Imię")]
        [MinLength(2)]
        [DataType(DataType.Text)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
#nullable enable
        public string? firstName { get; set; }
        [Display(Name = "Nazwisko")]
        [MinLength(2)]
        [DataType(DataType.Text)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string? lastName { get; set; }
        [Display(Name = "Płeć")]
        [StringLength(30)]
        public string? gender { get; set; }
        [Display(Name = "Data urodzenia")]
        [DataType(DataType.Date)]
        public string? birthDate { get; set; }
        #nullable disable
        [Display(Name = "Nazwa użytkownika")]
        [Required(ErrorMessage = "Pole 'Nazwa użytkownika' jest wymagane")]
        [DataType(DataType.Text)]
        [StringLength(30)]
        public string nickname { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Pole 'E-mail' jest wymagane")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        public string email { get; set; }
        [Display(Name = "Hasło")]
        [MinLength(6)]
        [StringLength(30)]
        public string password { get; set; }
        [StringLength(250)]
        [NotMapped]
        #nullable enable
        public string? passwordSalt { get; set; }
        [StringLength(250)]
        [NotMapped]
        public string? passwordIterCount { get; set; }
        [Display(Name = "Nr telefonu")]
        [StringLength(15)]
        [MinLength(7)]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        public string? phone { get; set; }
        #nullable disable
        public ICollection<Message> Messages { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
