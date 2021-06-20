using AnimalHealthApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHealthApp.Entities.Dtos
{
    public class AnimalUpdateDto
    {
        // According to Animal Map

        [Required]
        public int Id { get; set; }

        [DisplayName("İsim")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilmemelidir!")] // Hayvanın İsmi = {0}
        [MaxLength(100, ErrorMessage = "{0} Alanı {1} Karakterden Büyük Olmamalıdır!")]
        [MinLength(3, ErrorMessage = "{0} Alanı {1} Karakterden Az Olmamalıdır!")]
        public string Name { get; set; }

        [DisplayName("Tür")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir!")]
        [MinLength(5, ErrorMessage = "{0} Alanı {1} Karakterden Az Olmamalıdır!")] // Max does not exist because NVARCHAR(MAX)
        public string Type { get; set; }

        [DisplayName("Cins")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir!")]
        [MinLength(5, ErrorMessage = "{0} Alanı {1} Karakterden Az Olmamalıdır!")] // Max does not exist because NVARCHAR(MAX)
        public string Breed { get; set; }

        [DisplayName("Yaş")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilmemelidir!")]
        public int Age { get; set; }

        [DisplayName("Thumbnail")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilmemelidir!")]
        [MaxLength(250, ErrorMessage = "{0} Alanı {1} Karakterden Büyük Olmamalıdır!")]
        [MinLength(5, ErrorMessage = "{0} Alanı {1} Karakterden Az Olmamalıdır!")]
        public string Thumbnail { get; set; }

        [DisplayName("Tarih")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilmemelidir!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")] // Date format in turkey
        public DateTime Date { get; set; }

        [DisplayName("Seo Veteriner")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilmemelidir!")]
        [MaxLength(50, ErrorMessage = "{0} Alanı {1} Karakterden Büyük Olmamalıdır!")]
        [MinLength(0, ErrorMessage = "{0} Alanı {1} Karakterden Az Olmamalıdır!")]
        public string SeoVeterinary { get; set; }

        [DisplayName("Seo Açıklama")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilmemelidir!")]
        [MaxLength(50, ErrorMessage = "{0} Alanı {1} Karakterden Büyük Olmamalıdır!")]
        [MinLength(0, ErrorMessage = "{0} Alanı {1} Karakterden Az Olmamalıdır!")]
        public string SeoDescription { get; set; }

        [DisplayName("Seo Açıklama")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilmemelidir!")]
        [MaxLength(70, ErrorMessage = "{0} Alanı {1} Karakterden Büyük Olmamalıdır!")]
        [MinLength(5, ErrorMessage = "{0} Alanı {1} Karakterden Az Olmamalıdır!")]
        public string SeoTags { get; set; }

        [DisplayName("Veteriner Klinik")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilmemelidir!")]
        public int VeterinaryClinicId { get; set; }

        public VeterinaryClinic VeterinaryClinic { get; set; }

        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilmemelidir!")]
        public bool IsActive { get; set; }

        [DisplayName("Silinsin Mi?")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilmemelidir!")]
        public bool IsDeleted { get; set; }
    }
}
