using System;
using System.Threading;

namespace EternalQuest
{
    public static class ConsoleHelper
    {
        public static void SetColor(string element)
        {
            Console.ResetColor();
            switch (element.ToLower())
            {
                case "title":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "success":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "warning":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "error":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "highlight":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case "progress":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
        }

        public static void WriteColored(string text, string colorType)
        {
            SetColor(colorType);
            Console.Write(text);
            Console.ResetColor();
        }

        public static void WriteLineColored(string text, string colorType)
        {
            SetColor(colorType);
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void DisplayProgressBar(int current, int target, int width = 20)
        {
            double progress = Math.Min((double)current / target, 1.0);
            int filled = (int)(progress * width);
            
            Console.Write("[");
            WriteColored(new string('█', filled), "success");
            Console.Write(new string('-', width - filled));
            Console.Write($"] {current}/{target} ({progress:P0})");
        }

        public static void ShowCelebration(string message)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"   _____ _    _ ______ _____  _____ ");
            Console.WriteLine(@"  / ____| |  | |  ____|  __ \|  __ \");
            Console.WriteLine(@" | |    | |__| | |__  | |__) | |__) |");
            Console.WriteLine(@" | |    |  __  |  __| |  ___/|  ___/");
            Console.WriteLine(@" | |____| |  | | |____| |    | |    ");
            Console.WriteLine(@"  \_____|_|  |_|______|_|    |_|    ");
            Console.ResetColor();
            
            WriteLineColored($"\n  {message}", "success");
            if (OperatingSystem.IsWindows())
            {
                Console.Beep(440, 200); 
                Console.Beep(880, 400);
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public static void ShowStreakMessage(int streakDays)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            if (streakDays % 7 == 0)
            {
                int weeks = streakDays / 7;
                Console.WriteLine(@"  _____ _                 _    ");
                Console.WriteLine(@" / ____| |               | |   ");
                Console.WriteLine(@"| (___ | |_ __ _ _ __ ___| | __");
                Console.WriteLine(@" \___ \| __/ _` | '__/ __| |/ /");
                Console.WriteLine(@" ____) | || (_| | | | (__|   < ");
                Console.WriteLine(@"|_____/ \__\__,_|_|  \___|_|\_\");

                Console.WriteLine($"\n  {weeks} WEEK STREAK!");
            }
            else
            {
                Console.WriteLine(@"  _____ _               ");
                Console.WriteLine(@" / ____| |              ");
                Console.WriteLine(@"| (___ | |_ _ __ ___  __");
                Console.WriteLine(@" \___ \| __| '__/ _ \/ _|");
                Console.WriteLine(@" ____) | |_| | |  __/ (_ ");
                Console.WriteLine(@"|_____/ \__|_|  \___|\__|");

                Console.WriteLine($"\n  {streakDays} DAY STREAK!");
            }

            Console.ResetColor();
            if (OperatingSystem.IsWindows())
            {
                Console.Beep(523, 200); 
                Console.Beep(784, 400);
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public static void ShowLevelUp(int newLevel)
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                WriteColored("LEVEL UP!", "success");
                Console.Write(" Loading");
                for (int j = 0; j < i + 1; j++) Console.Write(".");
                Thread.Sleep(500);
            }

            Console.Clear();
            WriteLineColored(@"
      _                    _ 
     | |                  | |
     | |     _____   _____| |
     | |    / _ \ \ / / _ \ |
     | |___|  __/\ V /  __/ |
     \_____/\___| \_/ \___|_|", "success");

            WriteLineColored($"\nYou've reached level {newLevel}!", "highlight");
            WriteLineColored($"New title: {GetLevelTitle(newLevel)}", "success");
            if (OperatingSystem.IsWindows())
            {
                Console.Beep(440, 300); 
                Console.Beep(880, 600);
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private static string GetLevelTitle(int level)
        {
            return level switch
            {
                < 5 => "Novice",
                < 10 => "Apprentice",
                < 15 => "Adept",
                < 20 => "Expert",
                < 25 => "Master",
                < 30 => "Grandmaster",
                _ => "Legendary"
            };
        }
    }
}
