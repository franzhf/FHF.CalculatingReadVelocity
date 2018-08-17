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
            this._book = book ?? throw new NullReferenceException($"book should not be null");
            this._pomodoroSettings = pomodoroSettings ?? throw new NullReferenceException($"PomodoroSettings should not be null");
            this._timeSettings = timeSettings ?? throw new NullReferenceException($"timeSettings should not be null");
            ReadAll = true;
        }

        public VelocityRequired Execute()
        {
            var timeRequired = GetTimeRequiredToRead();
            var pomodoroRequired = GetPomodoroRequired(timeRequired);
            var sessionRequired = GetSessionRequired(pomodoroRequired);            
            var velocityRequired = new VelocityRequired(timeRequired, sessionRequired, pomodoroRequired);            

            return velocityRequired;
        }

        public double GetPomodoroRequired(TimeRequired timeRequired)
        {
            int totalMinutes = TimeUtils.ConvertFractionHoursToMinutes(timeRequired.GetFractionFormat());            
            double pomodoroInFraction = TimeUtils.DecimalDivisionRound(totalMinutes, _pomodoroSettings.PomodoroDuration);
            return pomodoroInFraction;
        }

        public double GetSessionRequired(double qtyOfRequiredPomodoros)
        {
            double sessionInFraction = TimeUtils.DecimalDivisionRound(qtyOfRequiredPomodoros, (double)_pomodoroSettings.NumberPomodoroPerSession);
            return sessionInFraction;
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