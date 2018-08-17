using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CRV.CoreComponent.UnitTesting
{
    [TestClass]
    public class TimeSettingsTest
    {


        [TestMethod]
        [ExpectedException(typeof(TimeSettingsOutRangeException), "Minute is out of range")]
        public void MinuteSet_ShouldBeThrownAnExceptionNumberOutOfTheRange()
        {
            // arragment
            var timeSettings = new TimeSettings();
            int number1 = 70;
            int number2 = -1;
            // act
            timeSettings.Minute = number1;
            timeSettings.Minute = number2;

            // assert
        }


        [TestMethod]
        [ExpectedException(typeof(TimeSettingsOutRangeException), "Second is out of range")]
        public void SecondSet_ShouldBeThrownAnExceptionNumberOutOfTheRange()
        {
            // arragment
            var timeSettings = new TimeSettings();
            int number1 = 70;
            int number2 = -1;

            // act
            timeSettings.Second = number1;
            timeSettings.Second = number2;
            // assert
        }

        [TestMethod]
        public void SecondSet()
        {
            // arragment
            var timeSettings = new TimeSettings();
            int number = 59;

            // act
            timeSettings.Second = number;

            // assert
            Assert.IsTrue(timeSettings.Second == number);
        }
    }
}
