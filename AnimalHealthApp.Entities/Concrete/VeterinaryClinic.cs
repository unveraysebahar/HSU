using AnimalHealthApp.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHealthApp.Entities.Concrete
{
    public class VeterinaryClinic : EntityBase, IEntity
    {
        // TODO: 
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Animal> Animals { get; set; }
        public ICollection<Veterinarian> Veterinarians { get; set; }
    }
}
