using CMS.API.Models;
using CMS.DATA.DTO;

namespace CMS.API.Services.ServicesInterface
{
    public interface IStacksService
    {
        ResponseDto<List<string>> GetStacks();
        Task<ResponseDto<List<UserDto>>> GetUsersByStack(string stackId);
        Task<ResponseDto<string>> DeleteStack(string stackId);
    }
}