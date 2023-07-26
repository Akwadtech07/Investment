using New_folder.Models.Dtos;
using New_folder.Repositories.Interfaces;
using New_folder.Services.Interfaces;

namespace New_folder.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public Task<Result<UserDto>> ChangePassword(ChangePasswordResquestModel request)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<IEnumerable<UserDto>>> GetAll()
        {
            var users = await _userRepository.GetAll();
            var listOfUsers = users.Select(user => new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Image = user.Image,
                Address = new AddressDto
                {
                    Nationality = user.Address.Nationality,
                    State = user.Address.State,
                    City = user.Address.City,
                    HomeAddress = user.Address.HomeAddress,
                    ZipCode = user.Address.ZipCode,
                },
                Role = new RoleDto
                {
                    Name = user.Role.Name,
                    Description = user.Role.Description,
                },

            }).ToList();

            return new Result<IEnumerable<UserDto>>
            {
                Message = "success",
                Success = true,
                Data = listOfUsers,
            };
        }
        public async Task<Result<IEnumerable<UserDto>>> GetAll(string id)
        {
            var users = await _userRepository.GetAllChatContact(id);
            var listOfUsers = users.Select(user => new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Image = user.Image,
            }).ToList();

            return new Result<IEnumerable<UserDto>>
            {
                Message = "success",
                Success = true,
                Data = listOfUsers,
            };
        }

        public async Task<Result<IEnumerable<UserDto>>> GetAllBroker()
        {
            var users = await _userRepository.GetAllBroker();
            var listOfUsers = users.Select(user => new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Image = user.Image,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = new AddressDto
                {
                    Nationality = user.Address.Nationality,
                    State = user.Address.State,
                    City = user.Address.City,
                    HomeAddress = user.Address.HomeAddress,
                    ZipCode = user.Address.ZipCode,

                }

            }).ToList();

            return new Result<IEnumerable<UserDto>>
            {
                Message = "success",
                Success = true,
                Data = listOfUsers,
            };
        }

        public async Task<Result<IEnumerable<UserDto>>> GetAllInvestor()
        {
            var users = await _userRepository.GetAllInvestor();
            var listOfUsers = users.Select(user => new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Image = user.Image,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = new AddressDto
                {
                    Nationality = user.Address.Nationality,
                    State = user.Address.State,
                    City = user.Address.City,
                    HomeAddress = user.Address.HomeAddress,
                    ZipCode = user.Address.ZipCode,

                }

            }).ToList();

            return new Result<IEnumerable<UserDto>>
            {
                Message = "success",
                Success = true,
                Data = listOfUsers,
            };
        }

        public async Task<Result<UserDto>> GetUser(string id)
        {
            var user = await _userRepository.GetUserAsync(id);
            if (user == null)
                return new Result<UserDto>
                {
                    Message = "failed",
                    Success = false,

                };
            return new Result<UserDto>
            {
                Message = "Success",
                Success = true,
                Data = new UserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Image = user.Image,
                    Address = new AddressDto
                    {
                        Nationality = user.Address.Nationality,
                        State = user.Address.State,
                        City = user.Address.City,
                        HomeAddress = user.Address.HomeAddress,
                        ZipCode = user.Address.ZipCode
                    },
                }
            };
        }

        public async Task<Result<UserDto>> Login(LoginRequestModel request)
        {
            var user = await _userRepository.GetUserAsync(a => a.Email == request.UserNameOrEmail || a.UserName == request.UserNameOrEmail && a.Password == request.Password);
            if (user == null)
                return new Result<UserDto>
                {
                    Message = "invalid cridentials",
                    Success = false,

                };

            return new Result<UserDto>
            {
                Message = "login successful",
                Success = true,
                Data = new UserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Image = user.Image,
                    Role = new RoleDto
                    {
                        Id = user.Role.Id,
                        Name = user.Role.Name,
                        Description = user.Role.Description

                    },


                }
            };
        }
    }
}





