using System;

namespace MindfulnessApp.Activities
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity()
        {
            Name = "Breathing";
            Description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }
        
        public override void RunActivity()
        {
            DisplayStartingMessage();
            int duration = int.Parse(Console.ReadLine());
            
            PrepareToBegin();
            
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(duration);
            
            while (DateTime.Now < endTime)
            {
                PauseWithBreathingAnimation(4, true);
                if (DateTime.Now >= endTime) break;
                
                PauseWithBreathingAnimation(6, false);
            }
            
            DisplayEndingMessage(duration);
        }
    }
}