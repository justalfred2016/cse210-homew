using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        private int _timesCompleted;
        private DateTime _lastCompletedDate;
        private int _currentStreak;
        private int _bestStreak;

        public EternalGoal(string name, string description, int points) 
            : base(name, description, points) 
        {
            _timesCompleted = 0;
            _lastCompletedDate = DateTime.MinValue;
            _currentStreak = 0;
            _bestStreak = 0;
        }

        public override void RecordEvent()
        {
            DateTime today = DateTime.Today;
            
            if (_lastCompletedDate.Date == today.AddDays(-1))
            {
                _currentStreak++;
                if (_currentStreak > _bestStreak)
                {
                    _bestStreak = _currentStreak;
                }
            }
            else if (_lastCompletedDate.Date < today.AddDays(-1))
            {
                _currentStreak = 1;
            }
            else if (_lastCompletedDate == DateTime.MinValue)
            {
                _currentStreak = 1;
                _bestStreak = 1;
            }

            _timesCompleted++;
            _lastCompletedDate = today;

            if (_currentStreak % 7 == 0)
            {
                ConsoleHelper.ShowStreakMessage(_currentStreak);
            }
        }

        public override bool IsComplete() => false; // Eternal goals are never complete

        public override string GetProgress()
        {
            Console.Write("  ");
            ConsoleHelper.SetColor("progress");
            Console.Write("[∞] ");
            ConsoleHelper.WriteColored($"{_name}", "highlight");
            Console.Write(": ");
            Console.ResetColor();
            Console.Write($"{_description} ");
            
            ConsoleHelper.WriteColored($"({_timesCompleted} times)", "progress");
            
            if (_currentStreak > 0)
            {
                Console.Write("  ");
                ConsoleHelper.WriteColored($"🔥 {_currentStreak}-day streak", 
                    _currentStreak >= 7 ? "success" : "warning");
            }
            
            if (_lastCompletedDate != DateTime.MinValue)
            {
                Console.Write("  ");
                ConsoleHelper.WriteColored($"Last: {_lastCompletedDate:MMM d}", "progress");
            }
            
            return "";
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal|{_name}|{_description}|{_points}|{_timesCompleted}|" +
                   $"{_lastCompletedDate:yyyy-MM-dd}|{_currentStreak}|{_bestStreak}";
        }

        public void LoadStreakData(DateTime lastDate, int currentStreak, int bestStreak)
        {
            _lastCompletedDate = lastDate;
            _currentStreak = currentStreak;
            _bestStreak = bestStreak;
        }

        public int CurrentStreak => _currentStreak;
        public int BestStreak => _bestStreak;
        public DateTime LastCompletedDate => _lastCompletedDate;
    }
}