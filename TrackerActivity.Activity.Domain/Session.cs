using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerActivity.Domain.Activity
{
    public class Session: Entity
    {
        public Pomodoro Pomodoro { get; set; }
        public double NumberOfPomodoros { get; set; }        
        public int LongerBreak { get; set; }
        public TimeFormat TimeFormat { get; set; }
        public double DemandRate { get; set; }
        public Session()
        {
            Pomodoro = new Pomodoro();
        }
    }
}
