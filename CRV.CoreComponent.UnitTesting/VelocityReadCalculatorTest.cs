using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRV.CoreComponent.UnitTesting
{
    [TestClass]
    public class VelocityReadCalculatorTest
    {
        Book _book;
        PomodoroSettings _pomodoroSettings;
        TimeSettings _timeSettings;

        public VelocityReadCalculatorTest()
        {
            _book = new Book()
            {
                Title = "Clean code",
                Pages = 30,
                ISBN = "1233322",
                Author = "Robert C Martin"
            };

            _timeSettings = new TimeSettings()
            {
                Hour = 0,
                Minute = 2,
                Second = 0
            };

            _pomodoroSettings = new PomodoroSettings()
            {
                SinglePageVelocity = _timeSettings,
                PomodoroDuration = 30,
                NumberPomodoroPerSession = 3,
                RestAmongPomodoro = 5
            };
        }

        [TestMethod]
        public void CalculateReadVelocity_TimeRequired()
        {
            // Arrange : precondition of test             
            var velocityCalculator = new VelocityReadCalculator(_book, _pomodoroSettings, _timeSettings);

            // Act :  the performance of the act that is being tested
            var ResultVelocity = velocityCalculator.Execute();

            // assert: the assertion that the expected behavior occurred
            Assert.IsTrue(ResultVelocity.TimeRequired.Hour == 1);
            Assert.IsTrue(ResultVelocity.TimeRequired.Minute == 0);
            Assert.IsTrue(ResultVelocity.TimeRequired.Second == 0);
        }

        [TestMethod]
        public void CalculateReadVelocity_SessionRequired()
        {
            // Arrange : precondition of test             
            var velocityCalculator = new VelocityReadCalculator(_book, _pomodoroSettings, _timeSettings);

            // Act :  the performance of the act that is being tested
            var ResultVelocity = velocityCalculator.Execute();

            // assert: the assertion that the expected behavior occurred
            Assert.IsTrue(ResultVelocity.SessionRequired == 0);           
        }

        [TestMethod]
        public void CalculateReadVelocity_PomodorosRequired()
        {
            // Arrange : precondition of test             
            var velocityCalculator = new VelocityReadCalculator(_book, _pomodoroSettings, _timeSettings);

            // Act :  the performance of the act that is being tested
            var ResultVelocity = velocityCalculator.Execute();

            // assert: the assertion that the expected behavior occurred
            Assert.IsTrue(ResultVelocity.PomodorsRequired == 2);
        }

        [TestMethod]
        public void GetTimeRequiredToRead()
        {
            // arragment
            _timeSettings.Second = 30;
            var velocityCalculator = new VelocityReadCalculator(_book, _pomodoroSettings, _timeSettings);

            // act
            var timerRequiredResult = velocityCalculator.GetTimeRequiredToRead();

            //assert
            Assert.IsTrue(timerRequiredResult.Hour == 1);
            Assert.IsTrue(timerRequiredResult.Minute == 15);
        }

        [TestMethod]
        public void GetTimeRequiredToRead_DateTimeFormat()
        {
            // arragment
            _timeSettings.Second = 30;
            var velocityCalculator = new VelocityReadCalculator(_book, _pomodoroSettings, _timeSettings);

            // act
            var timerRequiredResult = velocityCalculator.GetTimeRequiredToRead();

            // 2 min and 30 seconds per page, 30 pages  should be 75 minutes
            // the result should be 1:15:00 One hour, fifteen minutes.

            //assert
            Assert.IsTrue(timerRequiredResult.GetDateTimeFormat() == DateTime.Parse("1:15:00"));
        }

        [TestMethod]
        public void GetTimeRequiredToRead_FractionFormat()
        {
            // arragment
            _timeSettings.Second = 30;
            var velocityCalculator = new VelocityReadCalculator(_book, _pomodoroSettings, _timeSettings);

            // act
            var timerRequiredResult = velocityCalculator.GetTimeRequiredToRead();

            // 2 min and 30 seconds per page, 30 pages  should be 75 minutes
            // 60 min --> 1 whole
            // 75 min --> ? part
            // the result should be 1.25 hours

            //assert
            Assert.IsTrue(timerRequiredResult.GetFractionFormat() == 1.25);
        }

        [TestMethod]
        public void GetPomodoroRequiredToRead()
        {
            // arragment
            var velocityCalculator = new VelocityReadCalculator(_book, _pomodoroSettings, _timeSettings);
            var timeRequired = velocityCalculator.GetTimeRequiredToRead();

            // act
            var pomodoroRequiredResult = velocityCalculator.GetPomodoroRequired(timeRequired);

            // 1 pomodoro -->  30 minutes, since the current pages is 30pg and the velocity per page is 2 min
            // the result should be 2p hours

            //assert
            Assert.IsTrue(pomodoroRequiredResult == 2);
        }

        [TestMethod]
        public void GetPomodoroRequiredToRead_OneMoreScenery()
        {
            // arragment
            _timeSettings.Second = 30;
            var velocityCalculator = new VelocityReadCalculator(_book, _pomodoroSettings, _timeSettings);
            var timeRequired = velocityCalculator.GetTimeRequiredToRead();

            // act
            var pomodoroRequiredResult = velocityCalculator.GetPomodoroRequired(timeRequired);

            // 1 pomodoro -->  30 minutes, since the current pages is 30pg and the velocity per page is 2.5 min
            // the result should be 2.15 p hours

            //assert
            Assert.IsTrue(pomodoroRequiredResult == 2.6);
        }

        [TestMethod]
        public void GetSessionRequiredToRead_totalpomodorosInIntegers()
        {
            // arragment

            var velocityCalculator = new VelocityReadCalculator(_book, _pomodoroSettings, _timeSettings);

            // act
            var sessionRequiredResult_2p = velocityCalculator.GetSessionRequired(2);
            var sessionRequiredResult_8p = velocityCalculator.GetSessionRequired(8);

            // 1 session -->  3p minutes
            // if the pomodoros is 2 , it will be return 0 --> (total pomodoros/ pomodoros per session)
            // if the pomodoros is 8 , it will be return 2.7 --> (8 / 3)            

            //assert
            Assert.IsTrue(sessionRequiredResult_2p == 0);
            Assert.IsTrue(sessionRequiredResult_8p == 2.7);
        }

        [TestMethod]
        public void GetSessionRequiredToRead_totalpomodorosDecimals()
        {
            // arragment
            var velocityCalculator = new VelocityReadCalculator(_book, _pomodoroSettings, _timeSettings);

            // act
            var sessionRequiredResult_3_5p = velocityCalculator.GetSessionRequired(3.5);
            var sessionRequiredResult_2_5p = velocityCalculator.GetSessionRequired(2.5);

            // 1 session -->  3p minutes
            // if the pomodoros is 3.5 , it will be return 1.2 --> (total pomodoros/ pomodoros per session)
            // if the pomodoros is 2.5 , it will be return 0 --> (2.5 / 3)   

            //assert
            Assert.IsTrue(sessionRequiredResult_3_5p == 1.2);
            Assert.IsTrue(sessionRequiredResult_2_5p == 0);
        }

    }
}
