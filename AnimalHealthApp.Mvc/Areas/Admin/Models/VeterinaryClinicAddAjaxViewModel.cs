using AnimalHealthApp.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalHealthApp.Mvc.Areas.Admin.Models
{
    public class VeterinaryClinicAddAjaxViewModel
    {
        public VeterinaryClinicAddDto VeterinaryClinicAddDto { get; set; }
        public string VeterinaryClinicAddPartial { get; set; }
        public VeterinaryClinicDto VeterinaryClinicDto { get; set; }
    }
}
