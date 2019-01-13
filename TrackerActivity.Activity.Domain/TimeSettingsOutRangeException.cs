using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerActivity.Domain.Activity
{
    public class TimeSettingsOutRangeException: Exception
    {
        static string _message = " is out of range";

        public TimeSettingsOutRangeException(string m) : base(m + _message)
        {


        }
    }
}
