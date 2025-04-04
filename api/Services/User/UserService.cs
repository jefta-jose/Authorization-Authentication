using api.Data;
using api.DTOs;
using api.Helpers;
using api.Models;
using api.Services.EmailService;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace api.Services.UserService
{
    public class UserService (Db_Context dbContext, IMapper mapper, IConfiguration configuration) : IUser
    {
        private readonly Db_Context db_Context = dbContext;
        private readonly IMapper _mapper = mapper;
        private readonly IConfiguration _configuration = configuration;
        public async Task<Result<UserDto>> CreateNewUser(CreateUserDto NewUser)
        {
            try
            {
                Guid Id = GuidExtensions.GenerateId();
                string HashedPassword = PasswordHasher.HashPassword(NewUser.Password);

                bool userExists = await CheckIfUserExists(NewUser.Email);

                if (userExists)
                {
                    return Result<UserDto>.Failed(HttpStatusCode.BadRequest, "User Already Exists", "", "");
                }

                User userToAdd = new()
                {
                    UserId = Id,
                    FirstName = NewUser.FirstName,
                    LastName = NewUser.LastName,
                    Email = NewUser.Email,
                    PasswordHash = HashedPassword,
                    Role = NewUser.Role
                };

                var result = _mapper.Map<UserDto>(userToAdd);
                db_Context.Add(userToAdd);
                await db_Context.SaveChangesAsync();

                string AppPassword = _configuration["AppPassword:PassWordValue"];

                await EmailSenderService.SendEmailAsync(userToAdd.Email, "Welcome To Auth and Auth", "You have successfully created an email at auth && auth limited", AppPassword);

                return Result<UserDto>.Success(HttpStatusCode.OK, result, "You Have Successfully created a new user");

            }

            catch(Exception ex)
            {
                return Result<UserDto>.Failed(HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message,"There was a problem processing your request");
            }
        }

        public async Task<bool> CheckIfUserExists(string Email)
        {
            User doesUserExist = await db_Context.Users.FirstOrDefaultAsync(user => user.Email == Email);

            if (doesUserExist == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
