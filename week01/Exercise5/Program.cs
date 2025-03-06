using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
     DisplayMessage();

     String UserName =PromptUserName();

     int num =PromptUserNumber();

     int square = SquareNumber(num);

     DisplayResults(UserName, square);

    
    }
    
    static void DisplayMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter Your favorite number: ");
        int numbers = int.Parse(Console.ReadLine());
        return numbers;
    } 

    static int SquareNumber(int num){
       int square = num * num;
       return square;
    }
    static void DisplayResults(string name, int square){
        Console.WriteLine($"{name}, the square of your number is {square} ");
    }
    
}