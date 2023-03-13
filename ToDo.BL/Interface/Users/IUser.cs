using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.BL.Helper;
using ToDo.BL.Model.AuthSeervices;
using ToDo.DAL.Entity;
using ToDo.DAL.Extend;

namespace ToDo.BL.Interface.Users
{
    public interface IUser
    {
        Task<IEnumerable<ApplicationUser>> GetAllUserAsync();
       Task UpdateUserAsync(ApplicationUser obj);
        Task DeleteAsync(ApplicationUser obj);
    }
}
