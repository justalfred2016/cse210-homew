using System;
using System.Collections.Generic;

namespace MindfulnessApp.Activities
{
    public class GratitudeActivity : Activity
    {
        private List<string> _gratitudePrompts = new List<string>
        {
            "What small things are you grateful for today?",
            "Who has helped you recently that you're thankful for?",
            "What abilities or talents are you grateful to have?",
            "What beautiful things have you noticed recently?",
            "What comforts are you grateful to have in your life?"
        };
        
        public GratitudeActivity()
        {
            Name = "Gratitude";
            Description = "This activity will help you cultivate gratitude by focusing on the positive aspects of your life.";
        }
        
        public override void RunActivity()
        {
            DisplayStartingMessage();
            int duration = int.Parse(Console.ReadLine());
            
            PrepareToBegin();
            
            Random random = new Random();
            string prompt = _gratitudePrompts[random.Next(_gratitudePrompts.Count)];
            Console.WriteLine("\nReflect on the following:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"--- {prompt} ---");
            Console.ResetColor();
            Console.WriteLine("\nWrite down as many things as you can think of:");
            
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(duration);
            
            List<string> items = new List<string>();
            Console.WriteLine();
            while (DateTime.Now < endTime)
            {
                Console.Write("I'm grateful for: ");
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    items.Add(item);
                }
            }
            
            Console.WriteLine($"\nYou expressed gratitude for {items.Count} things!");
            DisplayEndingMessage(duration);
        }
    }
}