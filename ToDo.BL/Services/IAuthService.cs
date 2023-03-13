using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.BL.Helper;
using ToDo.BL.Model.AuthSeervices;

namespace ToDo.BL.Services
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterVM model); 
        Task<AuthModel> GetTokenAsync(LoginVM model);
       Task<string> AddRoleAsync(UserInRoleVM model);

        //Task<AuthModel> RefreshTokenAsync(string token);
        //Task<bool> RevokeTokenAsync(string token);

    }
}
