namespace EternalQuest
{
    public class NegativeGoal : Goal
    {
        public NegativeGoal(string name, string description, int points) 
            : base(name, description, points) { }

        public override void RecordEvent()
        {
            // Negative goals don't get marked complete
        }

        public override bool IsComplete() => false;

        public override string GetProgress()
        {
            ConsoleHelper.SetColor("error");
            Console.Write($"[!] {_name}: ");
            Console.ResetColor();
            ConsoleHelper.WriteColored($"{_description} (lose {_points} points each time)", "warning");
            return "";
        }

        public override string GetStringRepresentation()
        {
            return $"NegativeGoal|{_name}|{_description}|{_points}";
        }
    }
}