using AnimalHealthApp.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHealthApp.Entities.Concrete
{
    public class Animal : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Thumbnail { get; set; }
        public DateTime Date { get; set; }
        public int ViewsHealthInformation { get; set; } = 0;
        public int HealthInformationCount { get; set; } = 0;

        /** 
            Search Engine Optimization (SEO) : Arama motoru optimizasyonu, 
            web sitelerini arama motorlarının daha rahat bir şekilde anlayabilmesi "taramasına" olanak sağlayacak şekilde arama motorlarının kriterlerine uygun hale getirilerek 
            "web sitesinin optimize edilmesi" hedeflenen anahtar kelimelere ait araba motoru aramalarında yükseltilmesidir. 
        **/

        public string SeoVeterinary { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTags { get; set; }
        public int VeterinaryClinicId { get; set; }
        public VeterinaryClinic VeterinaryClinic { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<HealthInformation> HealthInformations { get; set; } // May have more than one health information.
    }
}
