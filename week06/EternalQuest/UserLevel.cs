using System;

namespace EternalQuest
{
    public class UserLevel
    {
        private int _level;
        private int _experience;
        private int _experienceToNextLevel;

        public UserLevel()
        {
            _level = 1;
            _experience = 0;
            _experienceToNextLevel = 300;
        }

        public int Level => _level;
        public int Experience => _experience;
        public int ExperienceToNextLevel => _experienceToNextLevel;

        public void AddExperience(int points)
        {
            _experience += points;
            CheckLevelUp();
        }

        private void CheckLevelUp()
        {
            while (_experience >= _experienceToNextLevel)
            {
                _experience -= _experienceToNextLevel;
                _level++;
                _experienceToNextLevel = (int)(_experienceToNextLevel * 1.5);
                ConsoleHelper.ShowLevelUp(_level);
            }
        }

        public string GetLevelTitle()
        {
            return _level switch
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

        public string GetLevelInfo()
        {
            return $"Level: {_level} ({GetLevelTitle()})\n" +
                   $"Experience: {_experience}/{_experienceToNextLevel}";
        }

        public string GetStringRepresentation()
        {
            return $"{_level}|{_experience}|{_experienceToNextLevel}";
        }

        public void LoadFromString(string data)
        {
            string[] parts = data.Split('|');
            _level = int.Parse(parts[0]);
            _experience = int.Parse(parts[1]);
            _experienceToNextLevel = int.Parse(parts[2]);
        }
    }
}