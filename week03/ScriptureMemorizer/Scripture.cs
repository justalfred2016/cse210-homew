using System;
using System.Collections.Generic;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(_reference.GetDisplayText() + "\n");
        Console.WriteLine(string.Join(" ", _words.Select(word => word.GetDisplayText())));
    }

    public bool HideRandomWords(int numberToHide = 3)
    {
        List<Word> visibleWords = _words.Where(word => !word.IsHidden()).ToList();
        if (visibleWords.Count == 0)
        {
            return false; // All words are already hidden
        }

        Random random = new Random();
        for (int i = 0; i < Math.Min(numberToHide, visibleWords.Count); i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index); // Ensure the same word isn't hidden twice
        }
        return true;
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}