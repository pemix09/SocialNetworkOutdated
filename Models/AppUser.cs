using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class AppUser : IdentityUser
    {
        #nullable enable
        [Display(Name = "Imię")]
        [MinLength(2)]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string? FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        [MinLength(2)]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string? LastName { get; set; }
        [DataType(DataType.Text)]
        public string? ProfilePicture { get; set; }
        #nullable disable
        public ICollection<Message> Messages { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
