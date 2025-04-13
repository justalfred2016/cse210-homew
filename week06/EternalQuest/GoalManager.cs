using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;
        private UserLevel _userLevel;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
            _userLevel = new UserLevel();
        }

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                ConsoleHelper.WriteLineColored("=== Eternal Quest ===", "title");
                ConsoleHelper.WriteColored($"Current Score: ", "highlight");
                ConsoleHelper.WriteLineColored($"{_score}", "success");
                Console.WriteLine(_userLevel.GetLevelInfo());
                
                ConsoleHelper.WriteLineColored("\nMenu Options:", "title");
                string[] menuItems = {
                    "Create New Goal",
                    "Record Goal Progress",
                    "View All Goals",
                    "View Score and Level",
                    "Save Goals",
                    "Load Goals",
                    "Quit"
                };
                
                for (int i = 0; i < menuItems.Length; i++)
                {
                    ConsoleHelper.WriteColored($"{i + 1}. ", "highlight");
                    Console.WriteLine(menuItems[i]);
                }
                
                Console.Write("Select a choice from the menu: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        RecordGoalProgress();
                        break;
                    case "3":
                        DisplayGoals();
                        break;
                    case "4":
                        DisplayScore();
                        break;
                    case "5":
                        SaveGoals();
                        break;
                    case "6":
                        LoadGoals();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private void CreateGoal()
        {
            Console.Clear();
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("1. Simple Goal (one-time)");
            Console.WriteLine("2. Eternal Goal (repeating)");
            Console.WriteLine("3. Checklist Goal (requires multiple completions)");
            Console.WriteLine("4. Negative Goal (break a bad habit)");
            Console.Write("Which type of goal would you like to create? ");
            string typeChoice = Console.ReadLine();

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            switch (typeChoice)
            {
                case "1":
                    _goals.Add(new SimpleGoal(name, description, points));
                    break;
                case "2":
                    _goals.Add(new EternalGoal(name, description, points));
                    break;
                case "3":
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonus = int.Parse(Console.ReadLine());
                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                    break;
                case "4":
                    _goals.Add(new NegativeGoal(name, description, points));
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }

            Console.WriteLine("Goal created successfully!");
        }

        private void RecordGoalProgress()
        {
            Console.Clear();
            Console.WriteLine("Select a goal to record progress:");

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                _goals[i].GetProgress();
                Console.WriteLine();
            }

            Console.Write("Enter the number of the goal: ");
            if (int.TryParse(Console.ReadLine(), out int goalNumber) && goalNumber > 0 && goalNumber <= _goals.Count)
            {
                Goal selectedGoal = _goals[goalNumber - 1];
                selectedGoal.RecordEvent();

                if (selectedGoal is NegativeGoal)
                {
                    _score -= selectedGoal.Points;
                    ConsoleHelper.WriteLineColored($"\nYou lost {selectedGoal.Points} points for {selectedGoal.Name}.", "error");
                }
                else
                {
                    int pointsEarned = selectedGoal.Points;
                    
                    if (selectedGoal is ChecklistGoal checklistGoal && checklistGoal.IsComplete() && 
                        checklistGoal.CurrentCount == checklistGoal.TargetCount)
                    {
                        pointsEarned += checklistGoal.BonusPoints;
                        ConsoleHelper.WriteLineColored($"\nCongratulations! You earned {selectedGoal.Points} points for {selectedGoal.Name} " +
                                        $"plus a bonus of {checklistGoal.BonusPoints} points!", "success");
                    }
                    else
                    {
                        ConsoleHelper.WriteLineColored($"\nCongratulations! You earned {selectedGoal.Points} points for {selectedGoal.Name}!", "success");
                    }

                    _score += pointsEarned;
                    _userLevel.AddExperience(pointsEarned);
                }
            }
            else
            {
                Console.WriteLine("Invalid goal selection.");
            }
        }

        private void DisplayGoals()
        {
            ConsoleHelper.WriteLineColored("\nYOUR GOALS", "title");
            ConsoleHelper.WriteLineColored(new string('═', Console.WindowWidth), "progress");
            
            if (_goals.Count == 0)
            {
                ConsoleHelper.WriteLineColored("No goals created yet.", "warning");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                _goals[i].GetProgress();
                Console.WriteLine();
            }
            
            ConsoleHelper.WriteLineColored(new string('═', Console.WindowWidth), "progress");
            ConsoleHelper.WriteColored($"Total Goals: {_goals.Count}  ", "highlight");
            ConsoleHelper.WriteColored($"Completed: {_goals.Count(g => g.IsComplete())}  ", "success");
            ConsoleHelper.WriteColored($"In Progress: {_goals.Count(g => !g.IsComplete())}", "warning");
            Console.WriteLine();
        }

        private void DisplayScore()
        {
            Console.Clear();
            ConsoleHelper.WriteLineColored("=== YOUR PROGRESS ===", "title");
            ConsoleHelper.WriteColored("Current Score: ", "highlight");
            ConsoleHelper.WriteLineColored($"{_score}", "success");
            Console.WriteLine(_userLevel.GetLevelInfo());
            
            Console.WriteLine("\nProgress to next level:");
            int levelWidth = 30;
            int progressWidth = (int)((double)_userLevel.Experience / _userLevel.ExperienceToNextLevel * levelWidth);
            Console.Write("[");
            ConsoleHelper.WriteColored(new string('=', progressWidth), "success");
            Console.WriteLine(new string(' ', levelWidth - progressWidth) + "]");
            
            ConsoleHelper.WriteColored($"\nLevel {_userLevel.Level} ", "highlight");
            Console.WriteLine($"({_userLevel.GetLevelTitle()})");
        }

        private void SaveGoals()
        {
            Console.Write("Enter filename to save goals: ");
            string filename = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine($"Score|{_score}");
                outputFile.WriteLine($"Level|{_userLevel.GetStringRepresentation()}");

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved successfully!");
        }

        private void LoadGoals()
        {
            Console.Write("Enter filename to load goals: ");
            string filename = Console.ReadLine();

            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            _goals.Clear();
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');

                switch (parts[0])
                {
                    case "Score":
                        _score = int.Parse(parts[1]);
                        break;
                    case "Level":
                        _userLevel.LoadFromString(parts[1]);
                        break;
                    case "SimpleGoal":
                        var simpleGoal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                        if (bool.Parse(parts[4])) simpleGoal.RecordEvent();
                        _goals.Add(simpleGoal);
                        break;
                    case "EternalGoal":
                        var eternalGoal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                        eternalGoal.LoadStreakData(
                            DateTime.Parse(parts[5]),
                            int.Parse(parts[6]),
                            int.Parse(parts[7]));
                        _goals.Add(eternalGoal);
                        break;
                    case "ChecklistGoal":
                        var checklistGoal = new ChecklistGoal(
                            parts[1], parts[2], int.Parse(parts[3]), 
                            int.Parse(parts[4]), int.Parse(parts[6]));
                        for (int i = 0; i < int.Parse(parts[5]); i++)
                        {
                            checklistGoal.RecordEvent();
                        }
                        _goals.Add(checklistGoal);
                        break;
                    case "NegativeGoal":
                        _goals.Add(new NegativeGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;
                }
            }

            Console.WriteLine("Goals loaded successfully!");
        }
    }
}