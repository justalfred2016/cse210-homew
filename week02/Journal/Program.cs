using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    private static Timer reminderTimer;
    private static DateTime reminderTime;

    static void Main()
    {
        Journal journal = new Journal();
        bool running = true;

        // Initialize the reminder system
        InitializeReminderTimer();

        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Set a reminder");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    FileHandler.SaveToFile(saveFile, journal.GetEntries());
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    List<Entry> loadedEntries = FileHandler.LoadFromFile(loadFile);
                    journal.LoadEntries(loadedEntries);
                    break;
                case "5":
                    SetReminder();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    private static void InitializeReminderTimer()
    {
        // Create a timer that checks every second
        reminderTimer = new Timer(CheckReminder, null, 0, 1000);
    }

    private static void CheckReminder(object state)
    {
        if (DateTime.Now >= reminderTime)
        {
            Console.WriteLine("\nREMINDER: It's time to write in your journal!");
            Console.Beep(); // Optional: Play a sound to alert the user
            reminderTime = DateTime.MaxValue; // Disable the reminder after triggering
        }
    }

    private static void SetReminder()
    {
        Console.Write("Enter the reminder time (yyyy-MM-dd HH:mm:ss): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime userTime))
        {
            reminderTime = userTime;
            Console.WriteLine($"Reminder set for {reminderTime}");
        }
        else
        {
            Console.WriteLine("Invalid date/time format. Please try again.");
        }
    }
}