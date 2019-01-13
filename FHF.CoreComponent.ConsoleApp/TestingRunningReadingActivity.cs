using System;
using TrackerActivity.Toolkit;
using TrackerActivity.ManageRunningActivity;
using System.Diagnostics;
using TrackerActivity.DataAccess;
using TrackerActivity.Domain.Activity;

namespace FHF.CoreComponent.ConsoleApp
{
    public class TestingRunningReadingActivity
    {
        IDataProvider<ExecutableActivity> xmlDataProvider;
        
        public TestingRunningReadingActivity()
        {
            xmlDataProvider = new XMLDataProvider<ReadingExecutable>();            
        }
        public void Run(ActivityProcessor activityProcessor, IActivity mockActivity)
        {
            mockActivity.Name = "Clean Code";            
            ExecutableActivity executableActivity = new ReadingExecutable()
            {
                Activity = mockActivity
            };
            executableActivity.NotifyStopWatchChanges += DisplayActivity;
            activityProcessor.AddActivity(executableActivity);
            activityProcessor.Run(executableActivity.ID);
        }

        public  void DisplayActivity(ExecutableActivity executableActivity)
        {
            Console.WriteLine( "Seconds: " + executableActivity.ElapsedTime.TotalSeconds);
            Console.WriteLine("Minutes: " + executableActivity.ElapsedTime.TotalMinutes);
            xmlDataProvider.Write(executableActivity);
        }

    }
}
