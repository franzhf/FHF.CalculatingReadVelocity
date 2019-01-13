using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerActivity.Domain.Activity
{
    public class Pomodoro: Entity
    {
        public int PomodoroDuration { get; set; }
        public int ShortBreak { get; set; }
        public TimeFormat TimeFormat { get; set; }
        public double DemandRate { get; set; }
        public Guid ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Pomodoro()
        {
            
        }
    }
}
