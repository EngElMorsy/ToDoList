using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDo.BL.Const;
using ToDo.BL.Interface;
using ToDo.DAL.Database;
using ToDo.DAL.Entity;

namespace ToDo.BL.Repoistory
{
    public class ToDoRep : IToDoRep
    {
        private readonly ApplicationContext db;

        public ToDoRep(ApplicationContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<TD>> GetAsync(Expression<Func<TD, bool>> filter = null, Expression<Func<TD, object>> orderBy = null, string orderByDirection = "ASC")
        {
            IQueryable<TD> query = db.ToDo.Where(filter);
            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }
            return query.ToList();
        }

        public async Task<TD> GetByIdAsync(Expression<Func<TD, bool>> filter = null)
        {
            var data = await db.ToDo.Where(filter).
            FirstOrDefaultAsync();
            return data;
        }

        public async Task CreateAsync(TD obj)
        {
            obj.CreatedAt = DateTime.Now;
            await db.ToDo.AddAsync(obj);
            await db.SaveChangesAsync();
        }
        public async Task UpdateAsync(TD obj)
        {
            obj.UpdateAt = DateTime.Now;
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var OldData = db.ToDo.Find(id);
            db.ToDo.Remove(OldData);
            await db.SaveChangesAsync();
        }

        
      
    }
}
