using QubHQ_Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QubHQ_Services.Services.UserService
{
    public class UserService : IUserService
    {
        public Task<UserDto> DeleteUser(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> EditUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUserDetails(string id)
        {
            throw new NotImplementedException();
        }

        public Task<AuthenticationResultDto> Login(UserDto model)
        {
            throw new NotImplementedException();
        }

        public Task<AuthenticationResultDto> Register(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
