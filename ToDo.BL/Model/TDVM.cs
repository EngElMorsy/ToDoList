using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.BL.Model
{
    public class TDVM
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[Required(ErrorMessage = "Field Required")]
        //[MaxLength(100, ErrorMessage = "Max Lenght 100")]
        public string Titile { get; set; }
        //[MaxLength(500, ErrorMessage = "Max Lenght 500")]
        public string? Description { get; set; }
       // [Required(ErrorMessage = "Field Required")]
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
