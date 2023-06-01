using CMS.API.Models;
using CMS.API.Services.ServicesInterface;
using CMS.DATA.DTO;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.API.Services
{
    public class StacksService : IStacksService
    {
        private readonly IStacksRepo _stacksRepo;

        public StacksService(IStacksRepo stacksRepo)
        {
            _stacksRepo = stacksRepo;
        }

        public ResponseDto<List<string>> GetStacks()
        {
            var stacks = _stacksRepo.GetStacks();

            var response = new ResponseDto<List<string>>
            {
                StatusCode = 200,
                DisplayMessage = "All stacks returned",
                Result = stacks
            };

            return response;
        }

        public async Task<ResponseDto<List<UserDto>>> GetUsersByStack(string stackId)
        {
            var response = new ResponseDto<List<UserDto>>();
            try
            {
                var users = await _stacksRepo.GetUsersByStack(stackId);
                response.StatusCode = 200;
                response.DisplayMessage = "Stack users returned";
                response.Result = users;
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.DisplayMessage = "An error occurred while retrieving stack users";
                response.ErrorMessages = new List<string> { ex.Message };
            }
            if (response.Result == null)
            {
                response.Result = new List<UserDto>();
            }
            return response;
        }

        public async Task<ResponseDto<string>> DeleteStack(string stackId)
        {
            var response = new ResponseDto<string>();

            try
            {
                await _stacksRepo.DeleteStack(stackId);
                response.StatusCode = 200;
                response.DisplayMessage = "Stack deleted successfully";
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.ErrorMessages = new List<string> { ex.Message };
                return response;
            }
        }
    }
}