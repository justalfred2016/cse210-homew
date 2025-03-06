using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
   
    {
      //Create a list  
     List <int> numbers = new List<int>();
        
        //Create a while loop to keep getting numbers from a user
        int userInput = -1;
        while  (userInput != 0)
        {
         Console.Write("Enter a number: ");
         userInput =int.Parse(Console.ReadLine());
         
        //create an if statement to add numbers to the list if they are not zero
         if(userInput !=0)
         {
          numbers.Add(userInput);
         }
        }
        //test if the program is adding numbers to the list
         //Console.WriteLine(numbers.Count);
        //create a for each loop to view the numbers to make sure the calcualtions are working  
         //numbers.ForEach(Console.WriteLine);
        //Create a forEach loop to add the numbers 
         int add = 0;
        foreach (int number in numbers)
        {
            add += number;
        }
        Console.WriteLine($"The sum is: {add}");
        //Find the average
        float average = (float)add/numbers.Count;
        Console.WriteLine($"the Average is {average}");
        //use the max method to find the largest number
        int largest=numbers.Max();
        Console.WriteLine($"the Largest is {largest}");
    }

}