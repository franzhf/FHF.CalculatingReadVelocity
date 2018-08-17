using System;
using System.Collections.Generic;
using System.Text;

namespace CRV.CoreComponent
{
    public static class TimeUtil
    {
        const int WHOLEPART = 60;

        /// <summary>
        /// if the imput is 00:2:30  hh:mm:ss  the result will be 2.5 minutes
        /// </summary>
        /// <param name="inputTime"></param>
        /// <returns></returns>
        public static double ConvertDateTimeToFractionMinutes(DateTime inputTime)
        {
            double fractionPartOfSecond = (double)inputTime.Second / (double)WHOLEPART;
            double totalMinutesPlusFractionSec = (double)inputTime.Minute + fractionPartOfSecond;
            return totalMinutesPlusFractionSec;
        }
        
        /// <summary>
        /// if the imput is 1:30:00  hh:mm:ss  the result will be 1.5 hours
        /// </summary>
        /// <param name="inputTime"></param>
        /// <returns></returns>
        public static double ConvertDateTimeToFractionHours(DateTime inputTime)
        {
            double fractionPartMinute = (double)inputTime.Minute / (double)WHOLEPART;
            double totalHourPlusFractionMin = (double)inputTime.Hour + fractionPartMinute;
            return totalHourPlusFractionMin;
        }

        /// <summary>
        /// if the input is 1.5 hours  the result will be 75 minutes
        /// </summary>
        /// <param name="inputTime"></param>
        /// <returns></returns>
        public static int ConvertFractionHoursToMinutes(double inputHour)
        {
            double minutes = inputHour * (double) WHOLEPART;            
            return int.Parse(minutes.ToString());
        }

        public static bool ValidateHour(int h)
        {
            return (h < 24 && h > 0) ? true: false;
        }

        public static bool ValidateMinute(int m)
        {
            return (m < 60 && m >= 0) ? true : false;
        }

        public static bool ValidateSecond(int s)
        {
            return (s < 60 &&  s >= 0) ? true : false;
        }
    }
}
