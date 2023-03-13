using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.BL.Model.AuthSeervices
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Required Flied")]
        [StringLength(50, ErrorMessage = "Max len 50")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Required Flied")]
        [StringLength(50)]
        [MinLength(8, ErrorMessage = "Min len 8")]
        public string Password { get; set; }
    }
}
