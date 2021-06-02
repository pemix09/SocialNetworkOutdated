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
        [MinLength(2,ErrorMessage ="Minimalna długość imienia to 2 znaki")]
        [DataType(DataType.Text)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true, ErrorMessage ="Imię jest wymagane")]
        [StringLength(50, ErrorMessage ="Maksymalna długość imienia to 50 znaków")]
#nullable enable
        public string? firstName { get; set; }
        [Display(Name = "Nazwisko")]
        [MinLength(2, ErrorMessage ="Minimalna długość nazwiska to 2 znaki")]
        [DataType(DataType.Text)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true, ErrorMessage ="Nazwisko jest wymagane")]
        [StringLength(50,ErrorMessage ="Maksymalna długość nazwiska to 50 znaków")]
        public string? lastName { get; set; }
        [Display(Name = "Nr telefonu")]
        [StringLength(15, ErrorMessage ="Maksymalna długość numeru telefonu to 15 cyfr")]
        [MinLength(7, ErrorMessage ="Minimalna długość numeru telefonu to 7 cyfr")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true,ErrorMessage ="Numer telefonu jest wymagany")]
        public string? phone { get; set; }
        [Display(Name = "Nazwa użytkownika")]
        [Required(ErrorMessage = "Pole 'Nazwa użytkownika' jest wymagane")]
        [DataType(DataType.Text)]
        [StringLength(30, ErrorMessage ="Maksymalna długość nazwy użytkownika to 30 znaków")]
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
