using System;
using TrackerActivity.Domain.Activity;
using TrackerActivity.Domain.ReadingActivity;
using TrackerActivity.Toolkit;

namespace TrackerActivity.Application.Core
{
    [Obsolete("VelocityReadCalculator class is deprecated, use ReadingActivity instead of.")]
    public class VelocityReadCalculator
    {
        public Book Book { get; private set; }
        public PomodoroSettings PomodoroSettings { get; private set; }
        public TimeFormat TimeSettings { get; private set; }
        public bool ReadAll { get; set; }
        


        public VelocityReadCalculator(Book book, PomodoroSettings pomodoroSettings, TimeFormat timeSettings)
        {
            Book = book ?? throw new NullReferenceException($"book should not be null");
            PomodoroSettings = pomodoroSettings ?? throw new NullReferenceException($"PomodoroSettings should not be null");
            TimeSettings = timeSettings ?? throw new NullReferenceException($"timeSettings should not be null");
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
            int totalMinutes = FormatTimeUtility.ConvertFractionHoursToMinutes(timeRequired.GetFractionFormat());            
            double pomodoroInFraction = FormatTimeUtility.DecimalDivisionRound(totalMinutes, PomodoroSettings.PomodoroDuration);
            return pomodoroInFraction;
        }

        public double GetSessionRequired(double qtyOfRequiredPomodoros)
        {
            double sessionInFraction = FormatTimeUtility.DecimalDivisionRound(qtyOfRequiredPomodoros, (double)PomodoroSettings.NumberPomodoroPerSession);
            return sessionInFraction;
        }


        public TimeRequired GetTimeRequiredToRead()
        {
            double timeInvesmentPerPage = TimeSettings.GetFractionFormat();
            var minuteOfInvesment = Book.Pages * timeInvesmentPerPage;
            int hour = (int)minuteOfInvesment / 60; //60 second
            int minute = (int)minuteOfInvesment % 60;
            return new TimeRequired(hour, minute, 0) ;
        }
    }
}