using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SecondMVC.Models
{
    public class UserRegisterViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [DisplayName("Käyttäjänimi")]
        public string name { get; set; }

        [Required]
        [DisplayName("Salasana")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public bool Register { get; set; }
    }
}
