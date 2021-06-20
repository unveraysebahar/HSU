using AnimalHealthApp.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHealthApp.Entities.Concrete
{
    public class HealthInformation : EntityBase, IEntity
    {
        public string Title { get; set; }
        public string ExaminationAndClinicalProcedure { get; set; }
        public string DiagnosticImagingAndAdvancedDiagnosticMethod { get; set; }
        public string SurgicalTreatment { get; set; }
        public string VeterinaryDentistry { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
