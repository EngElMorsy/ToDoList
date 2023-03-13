using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DAL.Entity;

namespace ToDo.BL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepositry<TD> TD {get;}

        int Compelete();
    }
}
