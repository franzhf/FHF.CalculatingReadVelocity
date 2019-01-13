using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerActivity.Domain.Activity
{
    public abstract class Entity
    {
        Guid id;
        public Guid ID
        {
            get => id;
        }
        public Entity()
        {
            id = Guid.NewGuid();
        }
    }
}
