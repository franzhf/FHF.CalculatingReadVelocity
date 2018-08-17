using System;
using System.Collections.Generic;
using System.Text;

namespace CRV.CoreComponent
{
    public class TimeRequired
    {
        public int Minute { get; private set; }
        public int Second { get; private set; }
        public int Hour { get; private set; }

        private DateTime _DateTimeFormat;

        private double _FractionFormat;

        public TimeRequired(int h, int m, int s)
        {
            if (!TimeUtils.ValidateHour(h))
                throw new TimeSettingsOutRangeException("Hour");
            if (!TimeUtils.ValidateMinute(m))
                throw new TimeSettingsOutRangeException("Minute");
            if (!TimeUtils.ValidateSecond(s))
                throw new TimeSettingsOutRangeException("Second");
            Hour = h;
            Minute = m;
            Second = s;

            _DateTimeFormat = BuildDateTimeFormat();
            if (h == 0)
                _FractionFormat = TimeUtils.ConvertDateTimeToFractionMinutes(_DateTimeFormat);
            else
                _FractionFormat = TimeUtils.ConvertDateTimeToFractionHours(_DateTimeFormat);
        }

        public DateTime GetDateTimeFormat()
        {
            return _DateTimeFormat;
        }

        private DateTime BuildDateTimeFormat()
        {
            var date = DateTime.Now;

            return new DateTime(date.Year, date.Month, date.Day, Hour, Minute, Second);
        }

        public double GetFractionFormat()
        {
            return _FractionFormat;
        }
    }
}
