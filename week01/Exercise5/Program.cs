using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {

    //call all the functions
     DisplayMessage();

     String UserName =PromptUserName();

     int num =PromptUserNumber();

     int square = SquareNumber(num);

     DisplayResults(UserName, square);

    
    }
    //Create a function that displays a message
    static void DisplayMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }
    //Create a function that stores and returns a name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    //Create a function that stores and returns a number
    static int PromptUserNumber()
    {
        Console.Write("Please enter Your favorite number: ");
        int numbers = int.Parse(Console.ReadLine());
        return numbers;
    } 
    //Create a function that creates a reference a number from the a function and spuares and stores it.
    static int SquareNumber(int num){
       int square = num * num;
       return square;
    }
    //Create a function that reference the squared number and the name from aboove and displays them.
    static void DisplayResults(string name, int square){
        Console.WriteLine($"{name}, the square of your number is {square} ");
    }
    
}