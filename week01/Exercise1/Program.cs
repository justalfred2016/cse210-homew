using System;

class Program
{
    static void Main(string[] args)
    {
        //Get the user input for their firs and last name
        Console.Write("What is your first name?");
        string firstName = Console.ReadLine();

        Console.Write("What is your last name?");
        string lastName = Console.ReadLine();
        //Output their name and Last name
        Console.WriteLine($"Your name is : {lastName}, {firstName} {lastName}");
    }
}