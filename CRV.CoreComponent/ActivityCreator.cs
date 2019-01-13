using System;
using System.Collections.Generic;
using System.Text;
using TrackerActivity.Toolkit;
using TrackerActivity.Domain.Activity;
using TrackerActivity.Domain.ReadingActivity;

namespace TrackerActivity.Application.Core
{
    // Concrete class is responsable to create one or more concrete activities
    public class ActivityCreator : IActivityCreator
    {
        /// <summary>
        /// Gives us a way to encapsulate the instantions of concrete types
        /// </summary>
        /// <param name="activityType"></param>
        /// <returns></returns>
        public IActivity CreateActivity(ActivityType activityType)
        {
            
            switch (activityType)
            {
                case ActivityType.Reading:
                    return new ReadingActivity();
                case ActivityType.Coding:
                    return new NullActivity();
                default:
                    break;
            }
            // this is not a good idea 
            // create an epecial class or default class
            return new NullActivity();
        }
    }
}
