using System;
using AnimalHealthApp.Shared.Utilities.Results.ComplexTypes;

namespace AnimalHealthApp.Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; } // ResultStatus.Success ...
        public string Message { get; }
        public Exception Exception { get; }
    }
}
