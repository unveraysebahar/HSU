using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHealthApp.Entities.Dtos
{
    public class VeterinaryClinicUpdateDto
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

        [DisplayName("Not")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir!")]
        [MaxLength(500, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır!")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden Az Olmamalıdır!")]
        public string Note { get; set; }

        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir!")]
        public bool IsActive { get; set; }

        [DisplayName("Silindi Mi?")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir!")]
        public bool IsDeleted { get; set; }
    }
}
