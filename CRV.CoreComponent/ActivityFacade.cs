using System;
using System.Collections.Generic;
using System.Text;
using TrackerActivity.Toolkit;

namespace CRV.CoreComponent
{
    /// <summary>
    /// Provide a unified interface to a set of interfaces in a subsystem.
    /// A common design goal is to minimize the communication and dependencies between subsystems. 
    /// </summary>
    public class ActivityFacade
    {
       public IActivity GenerateActivity(ActivityType activityType)
        {
            IActivityCreator activityCreator = new ActivityCreator();
            return activityCreator.CreateActivity(ActivityType.Reading);
        }

        public void RunCalculateActivity(IActivity activity)
        {
            if (activity == null && activity.SessionSettings != null)
                throw new Exception("Settings a session before Calculate demand time by this activity");
            activity.CalculateDemandTime();
        }

    }
}
