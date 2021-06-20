using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHealthApp.Entities.Dtos
{
    public class UserLoginDto
    {
        [DisplayName("E-Posta")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir!")]
        [MaxLength(100, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır!")]
        [MinLength(10, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir!")]
        [MaxLength(30, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır!")]
        [MinLength(5, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
