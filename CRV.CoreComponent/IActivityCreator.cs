using System;
using System.Collections.Generic;
using System.Text;
using TrackerActivity.Toolkit;
namespace CRV.CoreComponent
{
    public interface IActivityCreator
    {
        IActivity CreateActivity(ActivityType type);
    }
}
