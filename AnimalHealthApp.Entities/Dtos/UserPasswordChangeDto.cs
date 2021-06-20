using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHealthApp.Entities.Dtos
{
    public class UserPasswordChangeDto
    {
        [DisplayName("Şu Anki Şifre")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir!")]
        [MaxLength(30, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır!")]
        [MinLength(5, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır!")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [DisplayName("Yeni Şifre")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir!")]
        [MaxLength(30, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır!")]
        [MinLength(5, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır!")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DisplayName("Yeni Şifre Tekrar")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir!")]
        [MaxLength(30, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır!")]
        [MinLength(5, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır!")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Girmiş Olduğunuz Yeni Şifreniz İle Yeni Şifrenizin Tekrarı Alanı Birbiri İle Uyuşmalıdır.")]
        public string RepeatPassword { get; set; }
    }
}
