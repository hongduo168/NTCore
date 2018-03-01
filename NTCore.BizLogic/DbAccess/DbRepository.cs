using Microsoft.EntityFrameworkCore;
using NTCore.DataAccess;
using NTCore.DataAccess.DAL;
using NTCore.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTCore.BizLogic.DbAccess
{
    public class DbRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MainContext dbContext;

        public DbRepository(MainContext dbContext) => this.dbContext = dbContext;

        public void Add(T entity, bool autoSave = true)
        {
            this.dbContext.Set<T>().Add(entity);
            if (autoSave)
            {
                this.dbContext.SaveChanges();
            }
        }

        public void Delete(T entity, bool autoSave = true)
        {
            this.dbContext.Set<T>().Remove(entity);
            if (autoSave)
            {
                this.dbContext.SaveChanges();
            }
        }

        public T Get(int id)
        {
            return this.dbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> List()
        {
            return this.dbContext.Set<T>().AsEnumerable();

        }

        public IEnumerable<T> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return this.dbContext.Set<T>()
                      .Where(predicate)
                      .AsEnumerable();

        }

        public void Remove(T entity, bool autoSave = true)
        {
            entity.DataState = DataStateType.Delete;

            this.dbContext.Entry(entity).State = EntityState.Modified;
            if (autoSave)
            {
                this.dbContext.SaveChanges();
            }

        }

        public void Update(T entity, bool autoSave = true)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            if (autoSave)
            {
                this.dbContext.SaveChanges();
            }
        }
    }
}
