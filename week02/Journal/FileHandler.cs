using System;
using System.Collections.Generic;
using System.IO;

public static class FileHandler
{
    public static void SaveToFile(string filename, List<Entry> entries)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date} {entry.Prompt}");
                writer.WriteLine($"{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public static List<Entry> LoadFromFile(string filename)
    {
        List<Entry> entries = new List<Entry>();

        if (File.Exists(filename))
        {
            foreach (var line in File.ReadAllLines(filename))
            {
                string[] part = line.Split();
                if (part.Length == 3)
                {
                    entries.Add(new Entry(part[1], part[2]) { Date = part[0] });
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
        return entries;
    }
}
