using New_folder.Models.Dtos;

namespace New_folder.Services.Interfaces
{
    public interface IUserService
    {
        Task<Result<UserDto>> Login(LoginRequestModel request);
        Task<Result<UserDto>> ChangePassword(ChangePasswordResquestModel request);
        Task<Result<IEnumerable<UserDto>>> GetAll();
        Task<Result<IEnumerable<UserDto>>> GetAll(string id);
        Task<Result<IEnumerable<UserDto>>> GetAllBroker();
        Task<Result<IEnumerable<UserDto>>> GetAllInvestor();
        Task<Result<UserDto>> GetUser(string id);
    }
}
