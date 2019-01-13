using System;
using TrackerActivity.Toolkit;

namespace TrackerActivity.Domain.Activity
{
    public class TimeFormat
    {
        private int _minute = -1;
        private int _second = -1;
        private DateTime _dateTimeFormat;
        private double _fractionFormat;

        public int Minute
        {
            get
            {
                return _minute;
            }
            set
            {
                if (value > 59 || value < 0)
                    throw new TimeSettingsOutRangeException("Minute is out of range");
                _minute = value;
            }
        }

        public TimeFormat()
        {
            _fractionFormat = -1;
        }

        public TimeFormat(int h, int m, int s)
        {
            Hour = h;
            Minute = m;
            Second = s;

            _dateTimeFormat = BuildDateTimeFormat();
            if (h == 0)
                _fractionFormat = FormatTimeUtility.ConvertDateTimeToFractionMinutes(_dateTimeFormat);
            else
                _fractionFormat = FormatTimeUtility.ConvertDateTimeToFractionHours(_dateTimeFormat);
        }

        public int Hour { get; set; }


        public int Second
        {
            get
            {
                return _second;
            }
            set
            {
                if (value > 59 || value < 0)
                    throw new TimeSettingsOutRangeException("Second");
                _second = value;
            }
        }

        public DateTime GetDateTimeFormat()
        {
            if (_dateTimeFormat == null)
                _dateTimeFormat = new DateTime(1, 1, 1, Hour, Minute, Second);
            return _dateTimeFormat;
        }

        public double GetFractionFormat()
        {
            if(_fractionFormat == -1)
                _fractionFormat = FormatTimeUtility.ConvertDateTimeToFractionMinutes(new DateTime(1, 1, 1, Hour, Minute, Second));
            return _fractionFormat;
        }

        public string GetVelocityTimeString()
        {
            return $"{Minute}:{Second}";
        }

        public double GetTimeInMinutes()
        {
            int extractMinutesOfHours = Hour * 60;
            return extractMinutesOfHours + Minute;
        }

        private DateTime BuildDateTimeFormat()
        {
            var date = DateTime.Now;

            return new DateTime(date.Year, date.Month, date.Day, Hour, Minute, Second);
        }
    }
}