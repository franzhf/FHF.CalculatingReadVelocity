using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using TrackerActivity.Domain.Activity;
using TrackerActivity.Toolkit;
namespace TrackerActivity.Domain.ReadingActivity
{
    [Serializable]
    public class ReadingActivity : Entity, IActivity
    { 
        public Book Book { get; }
        public string Name { get; set; }
        
        public Session DemandSession { get; }
        public Session SessionSettings { get; set; }
        public int demandOfSessions { get; set; }
        public TimeFormat SinglePageVelocity { get; set; }
        public Guid ID { get; set; }

        public ReadingActivity()// we cannot create this activity wihtout a book
            // how is suppose we can create an instance of this activity
        {
            // use composition relationship instead of aggregation, not DI necesary since
            // this activity cannot create wihtout book
            // if we instance on here , why the clien code can setup the book's properties
            // S. the solution is allows to return the instance of a book
            // so that we can set up new values for book property
            Book = new Book();
            SessionSettings = new Session();
            DemandSession = new Session();
            ID = Guid.NewGuid();
        }

        public void CalculateDemandTime()
        {
            
            TimeFormat totalInvesmentTime = GetTimeRequiredToRead();
            double totalInvesmentPomodoro = GetPomodoroRequired(totalInvesmentTime);
            double totalInvesmentSession = GetSessionRequired(totalInvesmentPomodoro);

            DemandSession.TimeFormat = totalInvesmentTime;
            DemandSession.Pomodoro.DemandRate = totalInvesmentPomodoro;
            DemandSession.DemandRate = totalInvesmentSession;

            //var velocityRequired = new VelocityRequired(timeRequired, sessionRequired, pomodoroRequired);            
        }

        public double GetPomodoroRequired(TimeFormat timeRequired)
        {
            int totalMinutes = FormatTimeUtility.ConvertFractionHoursToMinutes(timeRequired.GetFractionFormat());
            double pomodoroInFraction = FormatTimeUtility.DecimalDivisionRound(totalMinutes, SessionSettings.Pomodoro.PomodoroDuration);
            return pomodoroInFraction;
        }

        public double GetSessionRequired(double qtyOfRequiredPomodoros)
        {
            double sessionInFraction = FormatTimeUtility.DecimalDivisionRound(qtyOfRequiredPomodoros, (double)SessionSettings.NumberOfPomodoros);
            return sessionInFraction;
        }

        public TimeFormat GetTimeRequiredToRead()
        {
            double timeInvesmentPerPage = SinglePageVelocity.GetFractionFormat();
            var minuteOfInvesment = Book.Pages * timeInvesmentPerPage;
            int hour = (int)minuteOfInvesment / 60; //60 second
            int minute = (int)minuteOfInvesment % 60;
            return new TimeFormat(hour, minute, 0);
        }

    }
}
