using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        // Example of the scripture
        Reference reference = new Reference("Doctrine and Covenant", 4, 1,7);
        string text = @"Now behold, a marvelous work is about to come forth among the children of men.
        2 Therefore, O ye that embark in the service of God, see that ye serve him with all your heart, might, mind and strength, that ye may stand blameless before God at the last day.;
        3 Therefore, if ye have desires to serve God ye are called to the work;4 For behold the field is white already to harvest; and lo, he that thrusteth in his sickle with his might, the same layeth up in store that he perisheth not, but bringeth salvation to his soul;
        5 And faith, hope, charity and love, with an eye single to the glory of God, qualify him for the work.
        6 Remember faith, virtue, knowledge, temperance, patience, brotherly kindness, godliness, charity, humility, diligence.
        7 Ask, and ye shall receive; knock, and it shall be opened unto you. Amen.";
        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            scripture.Display();
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit: ");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "quit")
            {
                break;
            }
            if (!scripture.HideRandomWords())
            {
                Console.WriteLine("\nAll words are hidden. Good job!");
                break;
            }
        }
    }
}






