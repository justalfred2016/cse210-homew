using System;
using System.Collections.Generic;

namespace MindfulnessApp.Activities
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        
        public ListingActivity()
        {
            Name = "Listing";
            Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        }
        
        public override void RunActivity()
        {
            DisplayStartingMessage();
            int duration = int.Parse(Console.ReadLine());
            
            PrepareToBegin();
            
            Random random = new Random();
            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine("\nList as many responses as you can to the following prompt:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"--- {prompt} ---");
            Console.ResetColor();
            PauseWithCountdown(5, "You may begin in: ");
            
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(duration);
            
            List<string> items = new List<string>();
            Console.WriteLine();
            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    items.Add(item);
                }
            }
            
            Console.WriteLine($"\nYou listed {items.Count} items!");
            DisplayEndingMessage(duration);
        }
    }
}