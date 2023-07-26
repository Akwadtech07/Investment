using New_folder.Models.Dtos;

namespace New_folder.Services.Interfaces
{
    public interface IInvestorService
    {
        Task<Result<InvestorDto>> Create(CreateInvestorRequestModel model);
        Task<Result<InvestorDto>> Get(string Id);
        Task<Result<IEnumerable<InvestorDto>>> GetAll();
    }
}
