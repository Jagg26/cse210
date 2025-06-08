using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Exploring Space", "NASA", 540);
        video1.AddComment(new Comment("Alice", "Amazing footage!"));
        video1.AddComment(new Comment("Bob", "This is so inspiring."));
        video1.AddComment(new Comment("Charlie", "I love this channel."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("How to Cook Pasta", "Chef Luigi", 300);
        video2.AddComment(new Comment("David", "Delicious recipe!"));
        video2.AddComment(new Comment("Emma", "I tried it and loved it."));
        video2.AddComment(new Comment("Frank", "Simple and easy to follow."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Learn C# in 10 Minutes", "CodeMaster", 600);
        video3.AddComment(new Comment("Grace", "Very helpful!"));
        video3.AddComment(new Comment("Henry", "Great explanation."));
        video3.AddComment(new Comment("Isla", "Saved my exam prep."));
        videos.Add(video3);

        Video video4 = new Video("Top 10 Beaches", "TravelTime", 480);
        video4.AddComment(new Comment("Jack", "Adding this to my bucket list."));
        video4.AddComment(new Comment("Karen", "So beautiful!"));
        video4.AddComment(new Comment("Leo", "Can’t wait to travel."));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.Name}: {comment.Text}");
            }

            Console.WriteLine(); // Blank line between videos
        }
    }
}
