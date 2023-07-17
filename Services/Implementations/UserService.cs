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

        public async Task<Result<UserDto>> GetUserAsync(string id)
        {
            var user = await _userRepository.GetUserAsync(id);
            if (user == null) return new Result<UserDto>
            {
                Message = "user not found",
                 Success= false,
            };
            return new Result<UserDto>
            {
                Message = "Success",
                Success = true,
                Data = new UserDto
                {
                 
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Image = user.Image,
                    Address = user.Address.Plot + " " + user.Address.Street + " " + user.Address.City + " " + user.Address.State,
                }
        }   };   

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
                Role = user.Roles.Select(a => new RoleDto
                {
                    Name = a.Role.Name,
                    Description = a.Role.Description,
                }).ToList(),

                 Address = user.Address.Select(a => new AddressDto
                { 
                  Nationality = a.Address.Nationality,
                  State = a.Address.State,
                  City = a.Address.City,
                  HomeAddress = a.Address.HomeAddress,
                  ZipCode = a.Address.ZipCode,



                }).ToList()

            });

            return new Result<IEnumerable<UserDto>>
            {
                Message = "success",
                Success = true,
                Data = listOfUsers,
            };
        }

        public async Task<Result<IEnumerable<UserDto>>> GetAll(int id)
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
                FirstName = user.User.FirstName,
                LastName = user.User.LastName,
                Image = user.User.Image,
                Email = user.User.Email,
                PhoneNumber = user.User.PhoneNumber,
                Address = user.User.Address.Street + " " + user.User.Address.City + " " + user.User.Address.State

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
                FirstName = user.User.FirstName,
                LastName = user.User.LastName,
                Image = user.User.Image,
                Email = user.User.Email,
                PhoneNumber = user.User.PhoneNumber,
                Address = user.User.Address.Street + " " + user.User.Address.City + " " + user.User.Address.State

            }).ToList();

            return new Result<IEnumerable<UserDto>>
            {
                Message = "success",
                Success = true,
                Data = listOfUsers,
            };
        }

        public async Task<Result<UserDto>> Login(LoginRequestModel request)
        {
            var user = await _userRepository.Get(a => a.Email == model.Email && a.Password == model.Password);
            if (user == null) return new Result<UserDto>
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
                    Role = user.Roles.Select(a => new RoleDto
                    {
                        Id = a.Role.Id,
                        Name = a.Role.Name,
                        Description = a.Role.Description

                    }).ToList(),


                }

            };
    }
    } }
