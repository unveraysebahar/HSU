using System.Threading.Tasks;
using AnimalHealthApp.Shared.Utilities.Results.Abstract;

namespace AnimalHealthApp.Services.Abstract
{
    public interface IHealthInformationService
    {
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByIsDeletedAsync();
    }
}
