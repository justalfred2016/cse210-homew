using System;
using MindfulnessApp.Activities;

namespace MindfulnessApp
{
    class Program
    {
        static void Main(string[] args)
        {  
            Console.Title = "Mindfulness App";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the Mindfulness App!");
            Console.ResetColor();
            
            Dictionary<string, Activity> activities = new Dictionary<string, Activity>
            {
                {"1", new BreathingActivity()},
                {"2", new ReflectionActivity()},
                {"3", new ListingActivity()},
                {"4", new GratitudeActivity()}
            };
            
            while (true)
            {
                Console.WriteLine("\nMenu Options:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Gratitude Activity (Bonus)");
                Console.WriteLine("5. View Activity Log");
                Console.WriteLine("6. Exit");
                Console.Write("Select a choice from the menu: ");
                
                string choice = Console.ReadLine();
                
                if (choice == "6")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nThank you for using the Mindfulness App. Have a peaceful day!");
                    Console.ResetColor();
                    break;
                }
                else if (choice == "5")
                {
                    Activity.ShowActivityLog();
                }
                else if (activities.ContainsKey(choice))
                {
                    try
                    {
                        activities[choice].RunActivity();
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please select 1-6.");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                }
            }
        }
    }
}