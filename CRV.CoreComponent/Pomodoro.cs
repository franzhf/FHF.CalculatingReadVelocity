using System;
using System.Collections.Generic;
using System.Text;

namespace CRV.CoreComponent
{
    public class Pomodoro
    {
        public int PomodoroDuration { get; set; }
        public int ShortBreak { get; set; }
        public TimeFormat TimeFormat { get; set; }
        public double DemandRate { get; set; }

        public Pomodoro()
        {
            
        }
    }
}
