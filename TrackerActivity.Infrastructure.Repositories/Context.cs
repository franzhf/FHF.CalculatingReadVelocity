using System;
using System.Collections.Generic;
using System.Text;
using TrackerActivity.Domain.Activity;

namespace TrackerActivity.Infrastructure.Repositories
{
    class Context
    {
        static Context context = new Context();
        Dictionary<Guid, Entity> data = new Dictionary<Guid, Entity>();

        public static Context GetContext()
        {
            return context;
        }

        public void Save(Entity entity)
        {
            data[entity.ID] = entity;
        }
    }
}


