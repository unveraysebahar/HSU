using AnimalHealthApp.Entities.Concrete;
using AnimalHealthApp.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalHealthApp.Mvc.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int VeterinaryClinicsCount { get; set; }
        public int AnimalsCount { get; set; }
        public int HealthInformationsCount { get; set; }
        public int UsersCount { get; set; }
        public AnimalListDto Animals { get; set; }
    }
}
