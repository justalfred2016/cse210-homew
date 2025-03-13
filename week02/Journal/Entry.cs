using System;

public class Entry
{
    public string _Date { get; }
    public string _Prompt { get; }
    public string _Response { get; }

    public Entry(string date, string prompt, string response)
    {
        _Date = date;
        _Prompt = prompt;
        _Response = response;
    }

    public override string ToString()
    {
        return $"Date: {_Date} Prompt: {_Prompt}\nResponse: {_Response}\n";
    }
}