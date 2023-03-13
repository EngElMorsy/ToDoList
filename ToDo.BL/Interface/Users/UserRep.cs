using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.BL.Helper;
using ToDo.BL.Model.AuthSeervices;
using ToDo.DAL.Extend;

namespace ToDo.BL.Interface.Users
{
    public class UserRep : IUser
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserRep(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }


        public async Task<IEnumerable<ApplicationUser>> GetAllUserAsync()
        {
            var data = await userManager.Users.ToListAsync();
            return (data);
        }


        public async Task UpdateUserAsync(ApplicationUser obj)
        {
            var result = await userManager.UpdateAsync(obj);
        }
        public async Task DeleteAsync(ApplicationUser obj)
        {
            var data = await userManager.FindByIdAsync(obj.Id);
             var result = await userManager.DeleteAsync(data);

        }
    }
}
