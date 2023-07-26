using Microsoft.AspNetCore;
using New_folder.Models.Dtos;
using New_folder.Models.Entities;
using New_folder.Repositories.Implementations;
using New_folder.Repositories.Interfaces;
using New_folder.Services.Interfaces;
using ServiceStack.Text;

namespace New_folder.Services.Implementations
{
    public class InvestorService : IInvestorService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IInvestorRepository _investorRepository;
        private readonly IWebHostEnvironment _webroot;

        public InvestorService(IUserRepository userRepository, IRoleRepository roleRepository,IWebHostEnvironment webroot, IInvestorRepository investorRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _webroot = webroot;
            _investorRepository = investorRepository;
        }
        public async Task<Result<InvestorDto>> Create(CreateInvestorRequestModel model)
        {
            var investorExist = _userRepository.Exists(a => a.Email == model.User.Email);
            if (investorExist)
            {
                

            }
            var address = new AddressDto
            {
                Nationality = model.Address.Nationality,
                State = model.Address.State,
                City = model.Address.City,
                HomeAddress = model.Address.HomeAddress,
                ZipCode = model.Address.ZipCode,

            };
            var userImage = "";

            if (model.User.Image != null)
            {
                string imagePath = Path.Combine(_webroot.WebRootPath, "UserImage");
                Directory.CreateDirectory(imagePath);
                string userImageType = model.IdentityImage.ContentType.Split('/')[1];
                userImage = $"{Guid.NewGuid()}.{userImageType}";
                var rightPath = Path.Combine(imagePath, userImage);
                using (var filestream = new FileStream(rightPath, FileMode.Create))
                {
                    model.IdentityImage.CopyTo(filestream);
                }
            }
            var role = await _roleRepository.GetRoleAsync(a => a.Name == "Investor");

            if (role == null)
            {
                return new Result<InvestorDto>
                {
                    Message = "role not found",
                    Success = false
                };
            }

            var user = new User
            {
                FirstName = model.User.FirstName,
                LastName = model.User.LastName,
                UserName = model.User.UserName,
                Email = model.User.Email,
                Password = model.User.Password,
                PhoneNumber = model.User.PhoneNumber,
                Gender = model.User.Gender,
                Image = userImage,
                RoleId = role.Id,
                Address = model.User.Address,
                AddressId = address.Id
            };

            var investor = new Investor
            {
                UserId = user.Id,
                User = user,
            };

            await _investorRepository.CreateAsync(investor);
            _investorRepository.SaveChangesAsync();

            return new Result<InvestorDto>
            {
                Message = "succesfully created",
                Success = true,
                Data = new InvestorDto
                {
                    Id = investor.Id,
                    IdentityImage = investor.IdentityImage,
                    User = new UserDto
                    {

                    },
                    IdentityType = investor.IdentityType,
                    BrokerId = investor.BrokerId,
                    UserId = user.Id,
                    Investments = investor.Investments,
                    CreatedDate = investor.CreatedDate,
                    IsDeleted = investor.IsDeleted,

                }
            };
        }

        public async Task<Result<InvestorDto>> Get(string Id)
        {
            var investor = await _investorRepository.GetInvestorAsync(Id);
            if (investor == null) return new Result<InvestorDto>
            {
                Message = "Not found",
                Success = false,
            };
            return new Result<InvestorDto>
            {
                Message = "succes",
                Success = true,
                Data = new InvestorDto
                {
                    Id = investor.Id,
                    IdentityImage = investor.IdentityImage,
                    IdentityType = investor.IdentityType,
                    BrokerId = investor.BrokerId,
                    Investments = investor.Investments,
                    CreatedDate = investor.CreatedDate,
                    IsDeleted = investor.IsDeleted,
                }
            };
        }
        
    public async Task<Result<IEnumerable<InvestorDto>>> GetAll()
        {
            var investor = await _investorRepository.GetAllInvestorAsync();
            var listOfInvestor = investor.Select(investor => new InvestorDto
            {
                Id = investor.Id,
                IdentityImage = investor.IdentityImage,
                User = new UserDto
                {

                },
                UserId = investor.UserId,
            }).ToList();

            return new Result<IEnumerable<InvestorDto>>
            {
                Message = "success",
                Success = true,
                Data = listOfInvestor,
            };
        }
    }
}
