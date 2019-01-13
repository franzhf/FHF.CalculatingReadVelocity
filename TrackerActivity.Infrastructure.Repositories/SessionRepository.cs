using System;
using System.Collections.Generic;
using System.Text;
using TrackerActivity.Domain.Activity;

namespace TrackerActivity.Infrastructure.Repositories
{
    public class SessionRepository: Repository<Session>
    {
        public override bool IsValid(Session entity)
        {
            return entity.Pomodoro != null;
        }
    }
}
