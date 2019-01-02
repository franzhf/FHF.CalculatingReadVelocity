using System;
using System.Collections.Generic;
using CRV.CoreComponent;
using TrackerActivity.Toolkit;

namespace TrackerActivity.ManageRunningActivity
{
    public interface IActivityProcessor
    {
        Dictionary<Guid, ExecutableActivity> ExecutableActivities { get;}
        void AddActivity(ExecutableActivity activity);
        void Stop(Guid ExecutableID);
        void Run(Guid ExecutableID);
        StateExecutableActivity GetExecutableActivityStatus(Guid ExecutableID);
        void Resume(Guid ExecutableID);
        void Cancel(Guid ExecutableID);

    }
}
