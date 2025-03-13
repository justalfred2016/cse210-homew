using System;

public class Job
{
    // Member variables
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    public Job(string company, string jobTitle, int startYear, int endYear){
      this._company = company;
      this._jobTitle = jobTitle;
      this._startYear = startYear;
      this._endYear = endYear;

    }

    // Display method
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}