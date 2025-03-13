using System;

class Program
{
    static void Main(string[] args)
    {


        // Create job instances
        Job job1 = new Job("Software Engineer", "Microsoft", 2019, 2022);
        Job job2 = new Job("Manager", "Apple", 2022, 2023);

        Resume myResume = new Resume();
        myResume._name = "Allison Rose";
        myResume.Display();
        // Display job details
         
        job1.Display();
        job2.Display();

    }
}