using System;

namespace ExerciseTracking
{

class Program
    {
        static void Main(string[] args)
        {
            // Create activities
            var activities = new List<Activity>
            {
                new Running(new DateTime(2022, 11, 3), 30, 3.0),
                new Cycling(new DateTime(2022, 11, 3), 30, 9.7),
                new Swimming(new DateTime(2022, 11, 3), 30, 40)
            };

            // Display summaries
            foreach (var activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
    }
    }
}