using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDo.BL.Const;
using ToDo.DAL.Entity;

namespace ToDo.BL.Interface
{
    public interface IToDoRep
    {
        Task<IEnumerable<TD>> GetAsync(Expression<Func<TD, bool>> filter = null,
        Expression<Func<TD, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);
        Task<TD> GetByIdAsync(Expression<Func<TD, bool>> filter = null);
        Task CreateAsync(TD  obj);
        Task UpdateAsync(TD obj);
        Task DeleteAsync(int id);
    }
}
