using System;
using System.Globalization;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator =  new Random();
        int number = randomGenerator.Next(1,101);
        //Console.WriteLine(number);
    
        int magicNumber = 1;
       while(number != magicNumber) 
       {
        Console.Write("Enter your Guess: ");
        magicNumber = int.Parse(Console.ReadLine());
         if(number > magicNumber)  
         {
            Console.WriteLine("higher");
        }
        else if(number < magicNumber)
        {
            Console.WriteLine("lower");
        }
        else
        {
            Console.WriteLine("You Guessed it!");
        }
       }
    }
}