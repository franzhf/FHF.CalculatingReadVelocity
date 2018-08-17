using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRV.CoreComponent.UnitTesting
{
    [TestClass]
    public class TimeUtilsTest
    {
        [TestMethod]
        public void ConvertDateTimeToFractionMinutes()
        {
            // arragment            

            // act
            var result = TimeUtils.ConvertDateTimeToFractionMinutes(DateTime.Parse("0:2:30"));

            // assert
            Assert.IsTrue(result == 2.5);
        }

        [TestMethod]
        public void ConvertDateTimeToFractionHours()
        {
            // arragment            

            // act
            var result = TimeUtils.ConvertDateTimeToFractionHours(DateTime.Parse("1:15:00"));

            // assert
            Assert.IsTrue(result == 1.25);
        }

        [TestMethod]
        public void ConvertFractionHoursToMinutes()
        {
            // arragment            

            // act
            var resultInMinutes = TimeUtils.ConvertFractionHoursToMinutes(1.25);

            // assert
            Assert.IsTrue(resultInMinutes == 75);
        }

        [TestMethod]
        public void DecimalDivisionRound()
        {
            // arragment

            // act
            var result = TimeUtils.DecimalDivisionRound(8, 3);

            // assert
            Assert.IsTrue(result == 2.7);
        }

    }

}
