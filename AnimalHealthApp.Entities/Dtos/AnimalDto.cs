using AnimalHealthApp.Entities.Concrete;
using AnimalHealthApp.Shared.Entities.Abstract;
using AnimalHealthApp.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHealthApp.Entities.Dtos
{
    public class AnimalDto : DtoGetBase
    {
        public Animal Animal { get; set; }

        // public override ResultStatus ResultStatus { get; set; } = ResultStatus.Success;
    }
}
