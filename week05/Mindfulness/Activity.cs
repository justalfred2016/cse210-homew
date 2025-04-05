using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp.Activities
{
    public abstract class Activity
    {
        protected string Name { get; set; }
        protected string Description { get; set; }
        protected static int ActivityCount { get; set; } = 0;
        protected static Dictionary<string, int> ActivityLog { get; } = new Dictionary<string, int>();
        
        protected void DisplayStartingMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"=== {Name} Activity ===");
            Console.ResetColor();
            Console.WriteLine($"\n{Description}");
            Console.Write("\nHow long, in seconds, would you like for your session? ");
        }
        
        protected void DisplayEndingMessage(int duration)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nGood job! You've done well.");
            this.PauseWithSpinner(3);  // Changed to instance call
            Console.WriteLine($"\nYou have completed the {Name} Activity for {duration} seconds.");
            this.PauseWithSpinner(3);  // Changed to instance call
            
            ActivityCount++;
            if (ActivityLog.ContainsKey(Name))
                ActivityLog[Name]++;
            else
                ActivityLog.Add(Name, 1);
            
            Console.ResetColor();
        }
        
        protected void PauseWithSpinner(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
        
        protected void PauseWithCountdown(int seconds, string message = "")
        {
            if (!string.IsNullOrEmpty(message))
                Console.Write(message);
                
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"{i} ");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
        
        protected void PauseWithBreathingAnimation(int seconds, bool breatheIn)
        {
            string message = breatheIn ? "Breathe in... " : "Breathe out... ";
            Console.Write(message);
            
            for (int i = 0; i < seconds; i++)
            {
                Console.Write("O");
                Thread.Sleep(1000);
                if (i < seconds - 1)
                    Console.Write("\b \b");
            }
            Console.WriteLine();
        }
        
        protected void PrepareToBegin()
        {
            Console.WriteLine("\nPrepare to begin...");
            this.PauseWithSpinner(3);  // Changed to instance call
        }
        
        public abstract void RunActivity();
        
        public static void ShowActivityLog()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n=== Activity Log ===");
            Console.WriteLine($"Total activities completed: {ActivityCount}");
            foreach (var entry in ActivityLog)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value} times");
            }
            Console.ResetColor();
            
            // Since this is static, we can't use instance methods here
            // So we'll create a temporary instance just for the spinner
            new BreathingActivity().PauseWithSpinner(3);
        }
    }
}