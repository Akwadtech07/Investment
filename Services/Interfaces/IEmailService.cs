using static New_folder.Models.Dtos.EmailDto;

namespace New_folder.Services.Interfaces
{
    public interface IEmailService
    {
        public void SendEMailAsync(EmailRequestModel mailRequest);
    }
}
