using System;
using CRV.CoreComponent;
namespace FHF.CoreComponent.ConsoleApp
{
    class Program
    {
        static VelocityReadCalculator _velocityReadCalculator;

        static void Main(string[] args)
        {
            Console.WriteLine($" Estimate how long you need to read a book");
            Menu();
        }

        private static void Menu()
        {
            string option = "D";
            while ((option = Console.ReadLine()) != "E")
            {
                switch (option)
                {
                    case "S":
                        LoadData();
                        // Run Process
                        VelocityRequired velocityRequired = _velocityReadCalculator.Execute();
                        ShowReport(velocityRequired);
                        break;
                    case "E":
                        return;
                    default:
                        ShowMainOptions();
                        break;
                }
            }
        }

        private static void ShowReport(VelocityRequired velocityRequired)
        {
            
            Console.WriteLine("****** Estimate Report ****** ");
            Console.WriteLine(" TIME ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"\t You need to investment about = {velocityRequired.TimeRequired.GetDateTimeFormat()}");
            Console.WriteLine($"\t About Hours = {velocityRequired.TimeRequired.GetFractionFormat()}  hrs");
            Console.WriteLine($"\t About Minutes = {velocityRequired.TimeRequired.Minute}  minutes");

            Console.WriteLine(" \n POMODORO ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"\t You need to investment about = {velocityRequired.PomodorsRequired}  pomodoros");

            Console.WriteLine(" \n SESSIONS ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"\t You need to investment about = {velocityRequired.SessionRequired}  sessions");

        }

        private static void LoadData()
        {
            Console.WriteLine("****** Enter a book ****** ");
            Book book = new Book();
            Console.WriteLine("Title: ");
            book.Title = Console.ReadLine();
            Console.WriteLine("Total Pages: ");
            book.Pages = Convert.ToInt16(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("****** Enter Time Settings ****** ");
            TimeSettings timeSettings = new TimeSettings();
            timeSettings.Hour = Convert.ToInt16(Console.ReadLine());
            timeSettings.Minute = Convert.ToInt16(Console.ReadLine());
            timeSettings.Second = Convert.ToInt16(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("****** Enter Pomodoro Settings ****** ");
            PomodoroSettings pomodoroSettings = new PomodoroSettings();
            Console.WriteLine("Pomodoro Per Session: 3");
            pomodoroSettings.NumberPomodoroPerSession = 3;
            Console.WriteLine("Pomodoro Duration: 30 min");
            pomodoroSettings.PomodoroDuration = 30;
            pomodoroSettings.SinglePageVelocity = timeSettings;
            Console.Clear();

            _velocityReadCalculator = new VelocityReadCalculator(book, pomodoroSettings, timeSettings);
        }

        private static void ShowMainOptions()
        {
            Console.WriteLine("****** Enter a option ****** ");
            Console.WriteLine("S Start");
            Console.WriteLine("E Exit");
            ;
        }
    }
}
