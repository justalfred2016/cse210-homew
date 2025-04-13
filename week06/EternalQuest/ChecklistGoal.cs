namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _currentCount;
        private int _bonusPoints;

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints) 
            : base(name, description, points) 
        {
            _targetCount = targetCount;
            _currentCount = 0;
            _bonusPoints = bonusPoints;
        }

        public override void RecordEvent()
        {
            _currentCount++;
            if (_currentCount >= _targetCount)
            {
                _isComplete = true;
                ConsoleHelper.ShowCelebration("Checklist Goal Complete!");
            }
        }

        public override bool IsComplete() => _isComplete;

        public override string GetProgress()
        {
            Console.Write("  ");
            string checkbox = _isComplete ? "[✓]" : "[ ]";
            ConsoleHelper.SetColor(_isComplete ? "success" : "progress");
            Console.Write($"{checkbox} ");
            ConsoleHelper.WriteColored($"{_name}", "highlight");
            Console.Write(": ");
            Console.ResetColor();
            Console.Write($"{_description} ");
            ConsoleHelper.DisplayProgressBar(_currentCount, _targetCount);
            return "";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal|{_name}|{_description}|{_points}|{_targetCount}|{_currentCount}|{_bonusPoints}";
        }

        public int BonusPoints => _bonusPoints;
        public int CurrentCount => _currentCount;
        public int TargetCount => _targetCount;
    }
}