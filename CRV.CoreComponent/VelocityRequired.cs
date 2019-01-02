using System;
using System.Collections.Generic;
using System.Text;

namespace CRV.CoreComponent
{
    [Obsolete("This class is deprecated")]
    public class VelocityRequired
    {
        public double SessionRequired { get; }
        public double PomodorsRequired { get; }

        public TimeRequired TimeRequired { get; }

        public VelocityRequired(TimeRequired timeRequired,double sessionRequired, double pomodoroRequired)
        {
            SessionRequired = sessionRequired;
            TimeRequired = timeRequired;
            PomodorsRequired = pomodoroRequired;
        }
    }
}
