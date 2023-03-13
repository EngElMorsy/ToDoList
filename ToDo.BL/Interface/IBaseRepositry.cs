using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDo.BL.Const;

namespace ToDo.BL.Interface
{
    public interface IBaseRepositry<T> where T : class
    {
        //filter and orderby 
         Task<IEnumerable<T> >GetAsync(Expression<Func<T, bool>> filter = null,
         Expression<Func<T, object>> orderBy = null, string orderByDirection =OrderBy.Ascending);

        // Get With Expression Or No Expression Return Collection FirstOrDefault
        Task<T> GetByIdAsync(Expression<Func<T, bool>> filter = null);
        Task CreateAsync(T obj);
        Task UpdateAsync(T obj);
        Task DeleteAsync(int id);
    }
}
