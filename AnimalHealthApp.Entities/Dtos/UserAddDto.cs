using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHealthApp.Entities.Dtos
{
    public class UserAddDto
    {
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir!")]
        [MaxLength(50, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır!")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır!")]
        public string UserName { get; set; }

        [DisplayName("E-Posta")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir!")]
        [MaxLength(100, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır!")]
        [MinLength(10, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir!")]
        [MaxLength(30, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır!")]
        [MinLength(5, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır!")] // Identity Configuration
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Telefon Numarası")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir!")]
        [MaxLength(13, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır!")] // +905355196880 : 13 characters
        [MinLength(13, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır!")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DisplayName("Resim")]
        [Required(ErrorMessage = "Lütfen, Bir {0} Seçiniz!")]
        [DataType(DataType.Upload)]
        public IFormFile PictureFile { get; set; }

        public string Picture { get; set; } // Keeping the name of the file
    }
}
