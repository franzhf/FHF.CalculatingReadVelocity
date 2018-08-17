using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRV.CoreComponent.UnitTesting
{
    [TestClass]
    public class TimeUtilTest
    {
        [TestMethod]
        public void ConvertDateTimeToFractionMinutes()
        {
            // arragment            

            // act
            var result = TimeUtil.ConvertDateTimeToFractionMinutes(DateTime.Parse("0:2:30"));

            // assert
            Assert.IsTrue(result == 2.5);
        }

        [TestMethod]
        public void ConvertDateTimeToFractionHours()
        {
            // arragment            

            // act
            var result = TimeUtil.ConvertDateTimeToFractionHours(DateTime.Parse("1:15:00"));

            // assert
            Assert.IsTrue(result == 1.25);
        }

        [TestMethod]
        public void ConvertFractionHoursToMinutes()
        {
            // arragment            

            // act
            var resultInMinutes = TimeUtil.ConvertFractionHoursToMinutes(1.25);

            // assert
            Assert.IsTrue(resultInMinutes == 75);
        }
    }

}
