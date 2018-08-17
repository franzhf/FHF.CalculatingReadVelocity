using System;
using System.Collections.Generic;
using System.Text;

namespace CRV.CoreComponent
{
    public class VelocityRequired
    {
        public int SessionRequired { get; }
        public double PomodorsRequired { get; }

        public TimeRequired TimeRequired { get; }

        public VelocityRequired(TimeRequired timeRequired,int sessionRequired, double pomodoroRequired)
        {
            SessionRequired = sessionRequired;
            TimeRequired = timeRequired;
            PomodorsRequired = pomodoroRequired;
        }
    }
}
