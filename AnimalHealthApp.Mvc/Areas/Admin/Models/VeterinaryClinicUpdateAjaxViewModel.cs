using AnimalHealthApp.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalHealthApp.Mvc.Areas.Admin.Models
{
    public class VeterinaryClinicUpdateAjaxViewModel
    {
        public VeterinaryClinicUpdateDto VeterinaryClinicUpdateDto { get; set; }
        public string VeterinaryClinicUpdatePartial { get; set; }
        public VeterinaryClinicDto VeterinaryClinicDto { get; set; }
    }
}
