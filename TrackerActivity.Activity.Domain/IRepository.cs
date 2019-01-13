using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerActivity.Domain.Activity
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(Guid id);

    }
}
