using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.BL.Model;
using ToDo.BL.Model.AuthSeervices;
using ToDo.DAL.Entity;
using ToDo.DAL.Extend;

namespace ToDo.BL.Mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<TD, TDVM>();
            CreateMap<TDVM, TD>();

            CreateMap<ApplicationUser, RegisterVM>();
            CreateMap<RegisterVM, ApplicationUser>();
        }
        
    }
}
