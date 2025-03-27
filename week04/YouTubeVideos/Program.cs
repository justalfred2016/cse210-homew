using System;
class Program
{
    static void Main(string[] args)
    {
        // Create videos
        var video1 = new Video("C# Tutorial for Beginners", "Programming Master", 600);
        var video2 = new Video("Abstract Classes Explained", "Code Guru", 450);
        var video3 = new Video("OOP Principles", "Software Engineer", 720);
        var video4 = new Video("C# Design Patterns", "Design Expert", 890);

        // Add comments to video1
        video1.AddComment(new Comment("User1", "Great tutorial!"));
        video1.AddComment(new Comment("User2", "Very helpful for beginners."));
        video1.AddComment(new Comment("User3", "Could you make one about inheritance?"));

        // Add comments to video2
        video2.AddComment(new Comment("Dev4", "Finally understand abstraction!"));
        video2.AddComment(new Comment("Coder5", "Clear explanation."));
        video2.AddComment(new Comment("Newbie6", "Need more examples please."));
        video2.AddComment(new Comment("SeniorDev", "Well structured content."));

        // Add comments to video3
        video3.AddComment(new Comment("Student7", "This helped me with my exam."));
        video3.AddComment(new Comment("Teacher8", "Using this in my class."));
        video3.AddComment(new Comment("Intern9", "Practical examples were great."));

        // Add comments to video4
        video4.AddComment(new Comment("Architect10", "Excellent coverage of patterns."));
        video4.AddComment(new Comment("JuniorDev", "Need to watch this again."));
        video4.AddComment(new Comment("TeamLead", "Sharing with my team."));

        // Create list of videos
        var videos = new List<Video> { video1, video2, video3, video4 };

        // Display video information
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}