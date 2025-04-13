namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points) 
            : base(name, description, points) { }

        public override void RecordEvent()
        {
            _isComplete = true;
        }

        public override bool IsComplete() => _isComplete;

        public override string GetProgress()
        {
            string checkbox = _isComplete ? "[✓]" : "[ ]";
            ConsoleHelper.SetColor(_isComplete ? "success" : "progress");
            Console.Write($"{checkbox} {_name}: ");
            Console.ResetColor();
            Console.Write(_description);
            return "";
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal|{_name}|{_description}|{_points}|{_isComplete}";
        }
    }
}