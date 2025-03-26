using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SecondMVC.Models
{
    public class UserRegisterViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [DisplayName("Nimi")]
        public string name { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Sähköpostiosoite")]
        public string email { get; set; }

        [Required]
        [DisplayName("Salasali")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
