using System;

namespace CRV.CoreComponent
{
    public class VelocityReadCalculator
    {
        private Book _book;
        private PomodoroSettings _pomodoroSettings;
        private TimeSettings _timeSettings;
        public bool ReadAll { get; set; }
        

        public VelocityReadCalculator(Book book, PomodoroSettings pomodoroSettings, TimeSettings timeSettings)
        {
            this._book = book;
            this._pomodoroSettings = pomodoroSettings;
            this._timeSettings = timeSettings;
            ReadAll = true;


        }

        public VelocityReadCalculator()
        {

        }

        public VelocityRequired Execute()
        {
            var timeRequired = GetTimeRequiredToRead();
            var pomodoroRequired = GetPomodoroRequired(timeRequired);
            var sessionRequired = GetSessionRequired();            
            var velocityRequired = new VelocityRequired(timeRequired, sessionRequired, pomodoroRequired);            

            return velocityRequired;
        }

        public double GetPomodoroRequired(TimeRequired timeRequired)
        {
            int totalMinutes = TimeUtil.ConvertFractionHoursToMinutes(timeRequired.GetFractionFormat());
            int totalPomodoros = totalMinutes / _pomodoroSettings.PomodoroDuration;
            int rest = totalMinutes % _pomodoroSettings.PomodoroDuration;
            return totalPomodoros + ((double)rest/100); // 100 get the decimal
        }

        private int GetSessionRequired()
        {
            throw new NotImplementedException();
        }

        public TimeRequired GetTimeRequiredToRead()
        {
            double timeInvesmentPerPage = _timeSettings.GetFractionFormat();
            var minuteOfInvesment = _book.Pages * timeInvesmentPerPage;
            int hour = (int)minuteOfInvesment / 60; //60 second
            int minute = (int)minuteOfInvesment % 60;
            return new TimeRequired(hour, minute, 0) ;
        }
    }
}