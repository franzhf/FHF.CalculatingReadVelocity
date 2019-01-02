using System;
using System.Collections.Generic;
using System.Text;
using CRV.CoreComponent;
using TrackerActivity.Toolkit;
using System.Threading;
using System.Xml.Serialization;

namespace TrackerActivity.ManageRunningActivity
{
    [Serializable]
    public abstract class ExecutableActivity
    {
        public delegate void NotifyChange(ExecutableActivity o);

        [XmlIgnore]
        [NonSerialized]
        public NotifyChange NotifyStopWatchChanges;
        private IActivity _activity;
        public Guid ID { get; set; }
        public StateExecutableActivity State { get; set; }

        public TimeSpan ElapsedTime { get; set; }

        [XmlIgnore]        
        public TimerCallback timerCallback { get; set; }
        public DateTime StartDate { get; set; }

        [XmlIgnore]
        public IActivity Activity
        {
            get { return _activity; }
            set
            {
                if (value == null)
                    throw new Exception("Need to set up the activity object");
                ID  = value.ID;
                _activity = value;
            }
        }

        public ExecutableActivity()
        {
            State = StateExecutableActivity.New;
            ElapsedTime = TimeSpan.Zero;
        }

        public virtual void StopWatch()
        {
            int duetime = 0;
            int intervalInMinutes = 1000 * 60;

            if (timerCallback == null)
                throw new NullReferenceException("Set a callback to the timerCallback property");
            TimerState timerState = new TimerState { Counter = 0 };
            Timer timer = new Timer(timerCallback, timerState, duetime, intervalInMinutes);
        }

        class TimerState
        {
            public int Counter;
        }
    }
}
