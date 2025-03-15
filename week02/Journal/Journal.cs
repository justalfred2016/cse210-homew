using System;
using System.Collections.Generic;

public class Journal
{
    public List<Entry> _entries;
    public List<string> _prompts;

    public Journal()
    {
        _entries = new List<Entry>();
        _prompts = new List<string>
        {
            "What is one way I can better support or uplift someone in my family or community this week?",
            "What was the best part of my day?",
            "How can I create more meaningful connections with the people around me?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What am I most grateful for today?",
            "What did I learn today?",
            "What’s one thing I’ve been overcomplicating in my life?"
        };
    }

    public void AddEntry()
    {
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        _entries.Add(new Entry(date, prompt, response));
        Console.WriteLine("Entry added successfully!");
    }

    public void DisplayJournal()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }

        foreach (var entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    public List<Entry> GetEntries()
    {
        return _entries;
    }

    public void LoadEntries(List<Entry> loadedEntries)
    {
        _entries = loadedEntries;
    }
    
}