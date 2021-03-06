using AnimalHealthApp.Entities.Concrete;
using AnimalHealthApp.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHealthApp.Entities.Dtos
{
    public class VeterinarianListDto : DtoGetBase
    {
        public IList<Veterinarian> Veterinarians { get; set; }
    }
}
