using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MindfulnessApp.Activities
{
    public class ReflectionActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        
        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
        
        private Queue<string> _availableQuestions;
        
        public ReflectionActivity()
        {
            Name = "Reflection";
            Description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
            ResetQuestions();
        }
        
        private void ResetQuestions()
        {
            var rnd = new Random();
            _availableQuestions = new Queue<string>(_questions.OrderBy(x => rnd.Next()));
        }
        
        public override void RunActivity()
        {
            DisplayStartingMessage();
            int duration = int.Parse(Console.ReadLine());
            
            PrepareToBegin();
            
            Random random = new Random();
            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine("\nConsider the following prompt:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"--- {prompt} ---");
            Console.ResetColor();
            Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
            Console.ReadLine();
            
            Console.WriteLine("\nNow ponder on each of the following questions as they relate to this experience.");
            PauseWithCountdown(5, "You may begin in: ");
            
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(duration);
            
            while (DateTime.Now < endTime)
            {
                if (_availableQuestions.Count == 0)
                    ResetQuestions();
                
                string question = _availableQuestions.Dequeue();
                Console.Write($"\n{question} ");
                PauseWithSpinner(5);
            }
            
            DisplayEndingMessage(duration);
        }
    }
}