using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.BL.Interface;
using ToDo.DAL.Database;
using ToDo.DAL.Entity;

namespace ToDo.BL.Repoistory
{
    public class UnitOfWork : IUnitOfWork
    {
        

        public IBaseRepositry<TD> TD { get; private set; } 

        private readonly ApplicationContext db;
        public UnitOfWork(ApplicationContext db)
        {
            this.db = db;
          
        }
        public int Compelete()
        {
            return db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose(); 
        }
    }
}
