using AnimalHealthApp.Shared.Utilities.Results.ComplexTypes;

namespace AnimalHealthApp.Shared.Entities.Abstract
{
    public abstract class DtoGetBase
    {
        public virtual ResultStatus ResultStatus { get; set; }
        public virtual string Message { get; set; }
    }
}
