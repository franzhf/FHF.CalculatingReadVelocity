using System;
using TrackerActivity.Toolkit;
using TrackerActivity.ManageRunningActivity;
using System.Diagnostics;
using TrackerActivity.Domain.Activity;
using TrackerActivity.Application.Core;
using TrackerActivity.Domain.ReadingActivity;

namespace FHF.CoreComponent.ConsoleApp
{
    class Program
    {
        static VelocityReadCalculator _velocityReadCalculator;
        static ActivityFacade _activityFacade;
        static ActivityProcessor activityProcessor = new ActivityProcessor();
        static TestingRunningReadingActivity testingRunningReadingActivity = new TestingRunningReadingActivity();

        static void Main(string[] args)
        {

            Menu();
        }

        private static void Menu()
        {
            _activityFacade = new ActivityFacade();
            var activity = _activityFacade.GenerateActivity(ActivityType.Reading);

            VelocityRequired velocityRequired;
            string option = "D";
            do
            {
                switch (option)
                {
                    case "S":
                        LoadData(activity);
                        _activityFacade.RunCalculateActivity(activity);
                        DisplayOnScreen(activity);
                        break;
                    case "E":
                        break;
                    case "C":
                        Console.Clear();
                        ShowMenu();
                        break;
                    case "L":
                        _activityFacade.RunCalculateActivity(activity);
                        DisplayOnScreen(activity);
                        break;
                    case "R":
                        // ShowDisplayActivities();
                        // testingRunningReadingActivity.Run(activityProcessor, new ReadingActivity());
                        /*ProcessStartInfo psi = new ProcessStartInfo("cmd.exe")
                        {
                            RedirectStandardError = true,
                            RedirectStandardInput = true,
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            Arguments = @"F:\LocalRepositories\FHF.CalculatingReadVelocity\FHF.CoreComponent.ConsoleApp\bin\Debug\netcoreapp2.1\"
                        };

                        Process p = Process.Start(psi);
                        StreamWriter sw = p.StandardInput;
                        StreamReader sr = p.StandardOutput;

                        sw.WriteLine("Hello world!");
                        sr.Close();*/

                        ProcessStartInfo psi1 = new ProcessStartInfo();
                        
                        psi1.UseShellExecute = false;
                        psi1.Arguments = @"F:\LocalRepositories\FHF.CalculatingReadVelocity\FHF.CoreComponent.ConsoleApp\bin\Debug\netcoreapp2.1\FHF.CoreComponent.ConsoleApp.exe";
                        psi1.FileName = "FHF.CoreComponent.ConsoleApp.exe";
                        Process p1 = Process.Start(psi1);
                        
                        
                        // psi1.Arguments = "/K yourmainprocess.exe";
                        p1.WaitForExit();

                        break;
                    default:
                        ShowMenu();
                        break;
                }
                option = Console.ReadLine().ToUpper();
            } while (option != "E");
        }

 
        private static void DisplayOnScreen(IActivity activity)
        {
            ReadingActivity readingActivity = (ReadingActivity)activity;
            var DemandSessionInfo = readingActivity.DemandSession;
            Console.WriteLine("****** Estimate Report ****** ");
            Console.WriteLine(" BOOK INFO ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"\t Title = {readingActivity.Book.Title}");
            Console.WriteLine($"\t Pages Need to Read = {readingActivity.Book.Pages} ");
            Console.WriteLine($"\t Velocity per page = {DemandSessionInfo.TimeFormat.GetVelocityTimeString()}");

            Console.WriteLine(" TIME ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"\t You need to investment about = {DemandSessionInfo.TimeFormat.GetDateTimeFormat().ToLongTimeString()}");
            Console.WriteLine($"\t About Hours = {DemandSessionInfo.TimeFormat.GetFractionFormat()}  hrs");
            Console.WriteLine($"\t About Minutes = {DemandSessionInfo.TimeFormat.GetTimeInMinutes()}  minutes");

            Console.WriteLine(" \n POMODORO ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"\t You need to investment about = {DemandSessionInfo.Pomodoro.DemandRate}  pomodoros");

            Console.WriteLine(" \n SESSIONS ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"\t You need to investment about = {DemandSessionInfo.DemandRate}  sessions");

        }

        private static void LoadData(IActivity activity)
        {
            ReadingActivity readingActivity = (ReadingActivity)activity;
            try
            {
                AddBookInfo(readingActivity.Book);
                

                Console.Clear();
                Console.WriteLine("****** Enter how long it takes you to read a single page ****** ");
                TimeFormat timeSettings = new TimeFormat();
                Console.WriteLine("Hour: ");
                timeSettings.Hour = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Minute: ");
                timeSettings.Minute = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Second: ");
                timeSettings.Second = Convert.ToInt16(Console.ReadLine());

                Console.Clear();
                Console.WriteLine("****** Enter the pomodoro information ****** ");
                // PomodoroSettings pomodoroSettings = new PomodoroSettings();
                Console.WriteLine("Pomodoro Per Session: 3");
                readingActivity.SessionSettings.NumberOfPomodoros = 3;
                Console.WriteLine("Pomodoro Duration: 30 min");
                readingActivity.SessionSettings.Pomodoro.PomodoroDuration = 30;
                readingActivity.SinglePageVelocity = timeSettings;
                Console.Clear();

                //_velocityReadCalculator = new VelocityReadCalculator(book, pomodoroSettings, timeSettings);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid entries!!!!!");
            }

        }

        private static void AddBookInfo(Book book)
        {
            Console.WriteLine("****** Enter a book ****** ");            
            Console.WriteLine("Title: ");
            if(book.Title == null)
                book.Title = Console.ReadLine();
            else
                Console.WriteLine(book.Title);

            Console.WriteLine("Total Pages: ");
            var tValue = Console.ReadLine();
            int intValue = 0;
            if (Int32.TryParse(tValue,out intValue))
                book.Pages = intValue;
            else
                AddBookInfo(book);
        }

        private static void ShowMenu()
        {

            Console.WriteLine($" Estimate how long you need to read a book");
            Console.WriteLine("****** Enter a option ****** ");
            Console.WriteLine("S Set up activity");
            Console.WriteLine("C Clear");
            Console.WriteLine("L Load the last one");
            Console.WriteLine("R Display Activities");
            Console.WriteLine("E Exit");
        }

        private static void ShowDisplayActivities()
        {
            int index = 0;
            Console.WriteLine("****** Select option ****** ");
            foreach (var executable in activityProcessor.ExecutableActivities.Values)
            {
                Console.WriteLine($"{index} Activity: {executable.Activity.Name} \t  - State: {executable.State} ");
                index++;
            }
        }
    }
}
