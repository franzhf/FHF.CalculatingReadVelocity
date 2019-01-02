using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using TrackerActivity.Toolkit;

namespace CRV.CoreComponent.UnitTesting
{
    [TestClass]
    public class ActitityTest
    {
        [TestMethod]
        public void CreateReadingActivity()
        {
            // arragment
            IActivityCreator activityCreator = new ActivityCreator();

            // act
            var readingActivity = activityCreator.CreateActivity(ActivityType.Reading);
            var response = readingActivity is IActivity;

            // assert
            Assert.IsTrue(response);
        }

        [TestMethod]
        public void CreateReadingActivityWithUsingConfigFile()
        {
            /*var collections = ConfigurationManager.AppSettings.AllKeys;

            // arragment
            IActivityCreator activityCreator = new ActivityCreatorWithConfig();

            // act
            var readingActivity = activityCreator.CreateActivity(ActivityType.Reading);
            var response = readingActivity is IActivity;

            // assert
            Assert.IsTrue(response);*/
        }
    }
}
