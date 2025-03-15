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
            writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
        }
    }
    Console.WriteLine("Journal saved successfully!");
}

public static List<Entry> LoadFromFile(string filename)
{
    List<Entry> loadedEntries = new List<Entry>();

    if (!File.Exists(filename))
    {
        Console.WriteLine("File does not exist. Creating a new file.");
        return loadedEntries;
    }

    using (StreamReader reader = new StreamReader(filename))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            Console.WriteLine($"Reading line: {line}");  // Debugging
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                loadedEntries.Add(new Entry(parts[0], parts[1], parts[2]));
            }
            else
            {
                Console.WriteLine($"Invalid entry format: {line}"); // Debugging
            }
        }
    }

    return loadedEntries;
}

}