using New_folder.Models.Dtos;

namespace New_folder.Services.Interfaces
{
    public interface IBrokerService
    {
        Task<Result<BrokerDto>> CreateBrokerAsync(CreateBrokerRequestModel model);
    }
}
