using System;
using System.Collections.Generic;
using System.Text;
using TrackerActivity.Toolkit;
using TrackerActivity.Domain.Activity;
namespace TrackerActivity.Application.Core
{
    public interface IActivityCreator
    {
        IActivity CreateActivity(ActivityType type);
    }
}
