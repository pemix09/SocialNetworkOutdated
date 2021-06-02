using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class InputModel
    {
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
        [Display(Name = "Nr telefonu")]
        [StringLength(15)]
        [MinLength(7)]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        public string? phone { get; set; }
        [Display(Name = "Nazwa użytkownika")]
        [Required(ErrorMessage = "Pole 'Nazwa użytkownika' jest wymagane")]
        [DataType(DataType.Text)]
        [StringLength(30)]
        public string? nickname { get; set; }
        [Required(ErrorMessage = "Adres email jest wymagany")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Należy powtórzyć adres email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Powtórz E-mail")]
        [Compare("Email", ErrorMessage = "Adresy E-mail są różne")]
        public string? confirmEmail { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [StringLength(100, ErrorMessage = "Hasło musi składać się z od 6 do 100 znaków", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło")]
        [Compare("Password", ErrorMessage = "Hasła są różne")]
        public string? ConfirmPassword { get; set; }
    }
}
