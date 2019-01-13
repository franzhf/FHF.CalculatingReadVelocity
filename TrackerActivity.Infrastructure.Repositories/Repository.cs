using System;
using System.Collections.Generic;
using System.Text;
using TrackerActivity.Domain.Activity;

namespace TrackerActivity.Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        public int Count { get; private set; }

        public void Add(T entity)
        {
            if (!IsValid(entity))
                throw new Exception($"{entity.GetType().Name} is not valid!!!");
            
            Context context = Context.GetContext();
            context.Save(entity);
            Count++;
        }

        public virtual bool IsValid(T entity)
        {
            return false;
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
