using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace CRV.CoreComponent.NET_Framework
{
    public class ActivityCreatorWithConfig : IActivityCreator
    {
        public ActivityCreatorWithConfig()
        {

        }

        public IActivity CreateActivity(string type)
        {
            // after referencing NuGet package System.Configuration.ConfigurationManager
            if (ConfigurationManager.AppSettings["RA"] == type)
                return new ReadingActivity();
            throw new Exception("The input type is not an activity");
        }
    }
}
