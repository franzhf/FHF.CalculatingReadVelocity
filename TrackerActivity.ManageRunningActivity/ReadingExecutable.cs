using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Timers;

namespace TrackerActivity.ManageRunningActivity
{
    public class ReadingExecutable : ExecutableActivity
    {
        public ReadingExecutable()
        {
        }

        public override void StopWatch()
        {
            Timer timer = new Timer();
            timer.Interval = 1000 * 60;
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.ElapsedTime = e.SignalTime - StartDate;
            if (NotifyStopWatchChanges == null)
                throw new Exception("Timer require an event handler");

            NotifyStopWatchChanges(this);
        }

    }
}
