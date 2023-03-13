using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.BL.Model.AuthSeervices
{
    public class RegisterVM
    {

        [Required, StringLength(50)]
        public string UserName { get; set; }
        [EmailAddress(ErrorMessage = "invalid email")]
        [Required, StringLength(100)]
        public string Email { get; set; }
        [Required, StringLength(50)]
        [MinLength(8, ErrorMessage = "Min len 8")]
        public string Password { get; set; }

      
    }
}
