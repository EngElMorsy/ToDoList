using FluentValidation;
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
    public class BaseRepositry<T> : IBaseRepositry<T> where T : class
    {
        private readonly ApplicationContext db;
        

        public BaseRepositry(ApplicationContext db)
        {
            this.db = db;
            ;
        } 


        public async Task<IEnumerable<T>>GetAsync(Expression<Func<T, bool>> filter = null,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending)
        {
             IQueryable<T> query = db.Set<T>().Where(filter);
             if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }
            return  query.ToList();
        }
       
        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> filter = null)
        {
            var data = await db.Set<T>().Where(filter).
               FirstOrDefaultAsync();

            return data;
        }

        public async Task CreateAsync(T obj)
        {
            //obj.DTCreation = DateTime.Now;
            await db.Set<T>().AddAsync(obj);
            //var result = await db.Set<T>().OrderByDescending(obj => obj.).FirstOrDefaultAsync();
            //return result;
        }
        public async Task UpdateAsync(T obj)
        {
            //obj.IsUpdate = true;
            //obj.DTUpdate = DateTime.Now;
            db.Entry(obj).State = EntityState.Modified;
            // await db.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var oldData = db.Set<T>().Find(id);
            //oldData.IsDelete = true;
            //oldData.DTDelete = DateTime.Now;
             db.Set<T>().Remove(oldData);
            // await db.SaveChangesAsync();
        }

       
       
    }
}
