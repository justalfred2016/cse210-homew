using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("Doctrine and Covenants", 4, 1, 7),
                @"1 Now behold, a marvelous work is about to come forth among the children of men. 
                2 Therefore, O ye that embark in the service of God, see that ye serve him with all your heart, might, mind and strength, that ye may stand blameless before God at the last day. 
                3 Therefore, if ye have desires to serve God ye are called to the work; 
                4 For behold the field is white already to harvest; and lo, he that thrusteth in his sickle with his might, the same layeth up in store that he perisheth not, but bringeth salvation to his soul; 
                5 And faith, hope, charity and love, with an eye single to the glory of God, qualify him for the work. 
                6 Remember faith, virtue, knowledge, temperance, patience, brotherly kindness, godliness, charity, humility, diligence. 
                7 Ask, and ye shall receive; knock, and it shall be opened unto you. Amen."),

            new Scripture(new Reference("Proverbs", 3, 5, 6),
                @"5 Trust in the Lord with all thine heart; and lean not unto thine own understanding. 
                6 In all thy ways acknowledge him, and he shall direct thy paths."),

            new Scripture(new Reference("John", 3, 16),
                @"16 For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),

            new Scripture(new Reference("Philippians", 4, 13),
                @"13 I can do all things through Christ which strengtheneth me.")
        };

        // Randomly select a scripture
        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

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






