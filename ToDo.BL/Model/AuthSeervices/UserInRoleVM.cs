using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.BL.Model.AuthSeervices
{
    public class UserInRoleVM
    {
        [Required(ErrorMessage ="Required UserId")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Required UserId")]
        public string RoleName { get; set; }
    }
}
