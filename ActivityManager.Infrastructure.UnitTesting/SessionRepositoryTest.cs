using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrackerActivity.Infrastructure.Repositories;
using TrackerActivity.Domain.Activity;
using TrackerActivity.Domain.ReadingActivity;

namespace ActivityManager.Infrastructure.UnitTesting
{
    [TestClass]
    public class SessionRepositoryTest
    {
        [TestMethod]
        public void Add_CheckNumberofSession()
        {
            SessionRepository sessionRepository = new SessionRepository();
            Session s1 = new Session
            {
                Pomodoro = new Pomodoro()
            };

            sessionRepository.Add(s1);
            Assert.AreEqual(1, sessionRepository.Count);
        }
    }
}
