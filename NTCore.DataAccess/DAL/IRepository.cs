using NTCore.DataModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NTCore.DataAccess.DAL
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(int id);
        IEnumerable<T> List();
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);
        void Add(T entity, bool autoSave = true);
        void Remove(T entity, bool autoSave = true);
        void Update(T entity, bool autoSave = true);
        void Delete(T entity, bool autoSave = true);

    }

}
