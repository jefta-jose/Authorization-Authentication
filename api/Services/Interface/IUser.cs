using api.DTOs;
using api.Helpers;

namespace api.Services.Interface
{
    public interface IUser
    {
        public Task<Result<UserDto>> CreateNewUser(CreateUserDto NewUser);
    }
}
