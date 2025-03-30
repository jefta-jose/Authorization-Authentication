using api.Data;
using api.DTOs;
using api.Helpers;
using api.Models;
using api.Services.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace api.Services
{
    public class UserService (Db_Context dbContext, IMapper mapper) : IUser
    {
        private readonly Db_Context db_Context = dbContext;
        private readonly IMapper _mapper = mapper;
        public async Task<Result<UserDto>> CreateNewUser(CreateUserDto NewUser)
        {
            try
            {
                Guid Id = GuidExtensions.GenerateId();

                User userToAdd = new()
                {
                    UserId = Id,
                    Name = NewUser.Name,
                    Role = NewUser.Role
                };

                var result = _mapper.Map<UserDto>(userToAdd);
                db_Context.Add(userToAdd);
                await db_Context.SaveChangesAsync();

                return Result<UserDto>.Success(HttpStatusCode.OK, result, "You Have Successfully created a new user");
            }

            catch(Exception ex)
            {
                return Result<UserDto>.Failed(HttpStatusCode.InternalServerError, ex.Message, "There was a problem processing your request");
            }
        }
    }
}
