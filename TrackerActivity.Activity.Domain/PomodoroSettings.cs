﻿namespace TrackerActivity.Domain.Activity
{
    public class PomodoroSettings
    {
        public PomodoroSettings()
        {
            IncludeRestAmongPomodoro = false;
            
        }

        public TimeFormat SinglePageVelocity { get; set; }
        public int PomodoroDuration { get; set; }
        public int NumberPomodoroPerSession { get; set; }
        public int RestAmongPomodoro { get; set; }

        public bool IncludeRestAmongPomodoro { get;private set; }
        
        
    }
}