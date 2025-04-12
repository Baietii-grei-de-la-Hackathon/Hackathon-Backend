using QubHQ_Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QubHQ_Services.Services.UserService
{
    public interface IUserService
    {
        Task<UserDto> DeleteUser(string email);
        Task<UserDto> EditUser(UserDto user);
        Task<AuthenticationResultDto> Login(UserDto model);
        Task<AuthenticationResultDto> Register(UserDto user);
        Task<UserDto> GetUserDetails(string id);

    }
}
