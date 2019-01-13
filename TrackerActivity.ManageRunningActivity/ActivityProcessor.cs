using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;
using System.Threading;
using TrackerActivity.Toolkit;

namespace TrackerActivity.ManageRunningActivity
{
    public class ActivityProcessor : IActivityProcessor
    {
        public Dictionary<Guid, ExecutableActivity> ExecutableActivities { get; }
        public Dictionary<Guid, Thread> threads;

        public ActivityProcessor()
        {
            ExecutableActivities = new Dictionary<Guid, ExecutableActivity>();            
            threads = new Dictionary<Guid, Thread>();
        }
        public void AddActivity(ExecutableActivity executableActivity)
        {
            // TODO: check contract
            Thread t = new Thread(executableActivity.StopWatch);
            threads.Add(executableActivity.ID, t);
            ExecutableActivities.Add(executableActivity.ID, executableActivity);
        }

        public StateExecutableActivity GetExecutableActivityStatus(Guid ExecutableID)
        {
            var executableActivity = GetOne(ExecutableID);
            var state = executableActivity == null ? throw new Exception(" Executable Activity was not found") : executableActivity.State;
            return state;
        }

        public void Run(Guid ExecutableID)
        {

            var executableActivity = GetOne(ExecutableID);
            if (executableActivity.State == StateExecutableActivity.New)
            {
                executableActivity.StartDate = DateTime.Now;
                Thread t = threads[ExecutableID];
                t.IsBackground = true;
                executableActivity.State = StateExecutableActivity.Running;
                t.Start();
            }
                
        }
        public void Stop(Guid ExecutableID)
        {
            var executableActivity = GetOne(ExecutableID);
            if (executableActivity.State == StateExecutableActivity.Running)
                executableActivity.State = StateExecutableActivity.Stop;
        }

        ExecutableActivity GetOne(Guid ExecutableID)
        {
            return ExecutableActivities[ExecutableID];
        }

        public void Resume(Guid ExecutableID)
        {
            var executableActivity = GetOne(ExecutableID);
            if (executableActivity.State == StateExecutableActivity.Stop)
                executableActivity.State = StateExecutableActivity.Running;
        }

        public void Cancel(Guid ExecutableID)
        {
            throw new NotImplementedException();
        }
    }
}
