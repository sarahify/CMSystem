using CMS.DATA.DTO;
using CMS.DATA.Entities;

namespace CMS.DATA.Repository.RepositoryInterface
{
    public interface IStacksRepo
    {
        List<string> GetStacks();
        Task<List<UserDto>> GetUsersByStack(string stackId);
        Task<bool> DeleteStack(string stackId);
    }
}