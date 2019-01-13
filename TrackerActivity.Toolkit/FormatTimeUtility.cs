using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerActivity.Toolkit
{
    public static class FormatTimeUtility
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
            return totalMinutesPlusFractionSec.RoundToOneDecimal();
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
            return totalHourPlusFractionMin.RoundToOneDecimal();
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

        public static double RoundToOneDecimal(this double value)
        {
            Decimal dValue = Convert.ToDecimal(value);
            return (double)Decimal.Round(dValue, 1);
        }

        public static double DecimalDivisionRound(double dividend, double divisor)
        {
            if (divisor > 0 && dividend < divisor)
                return 0;

            double quotient = dividend / divisor;            
            double remainder = dividend % divisor;
            double result =  quotient + (remainder / 100);  // remainder: 2 =>  0.2

            return result.RoundToOneDecimal();
        }
    }
}
