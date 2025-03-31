using api.DTOs;
using api.Helpers;

namespace api.Services.UserService
{
    public interface IUser
    {
        public Task<Result<UserDto>> CreateNewUser(CreateUserDto NewUser);
    }
}
