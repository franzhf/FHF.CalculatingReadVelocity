using System;
using CRV.CoreComponent;
namespace FHF.CoreComponent.ConsoleApp
{
    class Program
    {
        static VelocityReadCalculator _velocityReadCalculator;

        static void Main(string[] args)
        {
            
            Menu();
        }

        private static void Menu()
        {
            VelocityRequired velocityRequired;
            string option = "D";
            do
            {
                switch (option)
                {
                    case "S":
                        LoadData();
                        // Run Process
                        velocityRequired = _velocityReadCalculator.Execute();
                        ShowReport(velocityRequired);
                        break;
                    case "E":
                        break;
                    case "C":
                        Console.Clear();
                        ShowMainOptions();
                        break;
                    case "L":
                        velocityRequired = _velocityReadCalculator.Execute();
                        ShowReport(velocityRequired);
                        break;
                    default:
                        ShowMainOptions();
                        break;
                }
                option = Console.ReadLine().ToUpper();
            } while (option != "E");
        }

        private static void ShowReport(VelocityRequired velocityRequired)
        {
            
            Console.WriteLine("****** Estimate Report ****** ");
            Console.WriteLine(" BOOK INFO ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"\t Title = {_velocityReadCalculator.Book.Title}");
            Console.WriteLine($"\t Pages Need to Read = {_velocityReadCalculator.Book.Pages} ");
            Console.WriteLine($"\t Velocity per page = {_velocityReadCalculator.TimeSettings.GetVelocityTimeString()}");

            Console.WriteLine(" TIME ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"\t You need to investment about = {velocityRequired.TimeRequired.GetDateTimeFormat().ToLongTimeString()}");
            Console.WriteLine($"\t About Hours = {velocityRequired.TimeRequired.GetFractionFormat()}  hrs");
            Console.WriteLine($"\t About Minutes = {velocityRequired.TimeRequired.GetTimeInMinutes()}  minutes");

            Console.WriteLine(" \n POMODORO ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"\t You need to investment about = {velocityRequired.PomodorsRequired}  pomodoros");

            Console.WriteLine(" \n SESSIONS ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"\t You need to investment about = {velocityRequired.SessionRequired}  sessions");

        }

        private static void LoadData()
        {

            try
            {
                Console.WriteLine("****** Enter a book ****** ");
                Book book = new Book();
                Console.WriteLine("Title: ");
                book.Title = Console.ReadLine();
                Console.WriteLine("Total Pages: ");
                book.Pages = Convert.ToInt16(Console.ReadLine());

                Console.Clear();
                Console.WriteLine("****** Enter how long it takes you to read a single page ****** ");
                TimeSettings timeSettings = new TimeSettings();
                Console.WriteLine("Hour: ");
                timeSettings.Hour = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Minute: ");
                timeSettings.Minute = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Second: ");
                timeSettings.Second = Convert.ToInt16(Console.ReadLine());

                Console.Clear();
                Console.WriteLine("****** Enter the pomodoro information ****** ");
                PomodoroSettings pomodoroSettings = new PomodoroSettings();
                Console.WriteLine("Pomodoro Per Session: 3");
                pomodoroSettings.NumberPomodoroPerSession = 3;
                Console.WriteLine("Pomodoro Duration: 30 min");
                pomodoroSettings.PomodoroDuration = 30;
                pomodoroSettings.SinglePageVelocity = timeSettings;
                Console.Clear();

                _velocityReadCalculator = new VelocityReadCalculator(book, pomodoroSettings, timeSettings);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid entries!!!!!");
            }

        }

        private static void ShowMainOptions()
        {

            Console.WriteLine($" Estimate how long you need to read a book");
            Console.WriteLine("****** Enter a option ****** ");
            Console.WriteLine("S Start");
            Console.WriteLine("C Clear");
            Console.WriteLine("L Load the last one");
            Console.WriteLine("E Exit");
        }
    }
}
