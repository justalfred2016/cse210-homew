using System;
using System.Collections.Generic;
using System.IO;

public static class FileHandler
{
    public static void SaveToFile(string filename, List<Entry> entries)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine(value: $"{entry._Date} {entry._Prompt} {entry._Response}");
                }
            }
            Console.WriteLine("Journal saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public static List<Entry> LoadFromFile(string filename)
    {
        List<Entry> loadedEntries = new List<Entry>();

        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File does not exist. Creating a new file.");
                File.Create(filename).Close();
            }

            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        loadedEntries.Add(new Entry(parts[0], parts[1], parts[2]));
                    }
                }
            }

            // Display the loaded entries in the console
            if (loadedEntries.Count > 0)
            {
                Console.WriteLine("\nLoaded Entries:");
                foreach (var entry in loadedEntries)
                {
                    Console.WriteLine($"[{entry._Date}] Prompt: {entry._Prompt}\nResponse: {entry._Response}\n");
                }
            }
            else
            {
                Console.WriteLine("No entries found in the file.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }

        return loadedEntries;
    }
}