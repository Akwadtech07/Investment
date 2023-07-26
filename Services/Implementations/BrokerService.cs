using New_folder.Models.Dtos;
using New_folder.Services.Interfaces;

namespace New_folder.Services.Implementations
{
    public class BrokerService : IBrokerService
    {
        public Task<Result<BrokerDto>> CreateBrokerAsync(CreateBrokerRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
