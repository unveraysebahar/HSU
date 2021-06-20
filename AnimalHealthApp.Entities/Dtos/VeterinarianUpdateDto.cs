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
    public class VeterinarianUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("İsim")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir!")]
        [MaxLength(70, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır!")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden Az Olmamalıdır!")]
        public string Name { get; set; }

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir!")]
        [MaxLength(500, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır!")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden Az Olmamalıdır!")]
        public string Description { get; set; }

        [DisplayName("Veteriner Klinik")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilmemelidir!")]
        public int VeterinaryClinicId { get; set; }

        public VeterinaryClinic VeterinaryClinic { get; set; }
    }
}
