using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Emter Percentage Score: ");
        string userInput = Console.ReadLine();
       int  percentage =int.Parse(userInput);
        string letter ="";
        if (percentage >= 90)
        {
            letter = ("A");
        }
        else if (percentage >= 80)
        {
            letter =("B");
        }
        else if (percentage >= 70)
        {
            letter = ("C");
        }
        else if (percentage >= 60)
        {
            letter = ("D");
        }
        else
        {
            letter = ("F");
        } 
        Console.WriteLine(letter);
           if (percentage >= 70)
           {
            Console.WriteLine("Congrats, You Passed!");
           }
           else
           {
            Console.WriteLine("Better Luck next time");
           }
    }
}