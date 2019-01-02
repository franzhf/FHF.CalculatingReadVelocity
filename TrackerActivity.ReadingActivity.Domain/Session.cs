using System;
using System.Collections.Generic;
using System.Text;

namespace CRV.CoreComponent
{
    public class Session
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
