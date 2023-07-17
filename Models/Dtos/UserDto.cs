using New_folder.Models.Entities;
using New_folder.Models.Enums;

namespace New_folder.Models.Dtos
{
    public class UserDto : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Image { get; set; }
        public string AddressId { get; set; }
        public string RoleId { get; set; }
        public string Role { get; set; }
        public Investor Investor { get; set; }
        public InvestmentType Broker { get; set; }
    }

    public class CreateUserRequestModel : CreateAddressRequestModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public IFormFile Image { get; set; }
    }

    public class LoginRequestModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponseModel
    {

    }

    public class ChangePasswordResquestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class ForgetPasswordResquestModel
    {
        public string Email { get; set; }
    }
}
