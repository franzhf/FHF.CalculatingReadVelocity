using System;
namespace CRV.CoreComponent
{
    public class TimeSettings
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


        public TimeSettings()
        {
            _fractionFormat = -1;
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
                _fractionFormat = TimeUtils.ConvertDateTimeToFractionMinutes(new DateTime(1, 1, 1, Hour, Minute, Second));
            return _fractionFormat;
        }

        public string GetVelocityTimeString()
        {
            return $"{Minute}:{Second}";
        }
        
    }
}