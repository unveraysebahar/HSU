using AnimalHealthApp.Entities.Concrete;
using AnimalHealthApp.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHealthApp.Entities.Dtos
{
    public class UserDto : DtoGetBase
    {
        public User User { get; set; }
    }
}
