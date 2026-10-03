class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video(
            "How to Learn C#",
            "Code Academy",
            600);

        video1.AddComment(new Comment(
            "John",
            "This was very helpful!"));

        video1.AddComment(new Comment(
            "Sarah",
            "I finally understand classes."));

        video1.AddComment(new Comment(
            "Michael",
            "Great explanation of C#."));

        Video video2 = new Video(
            "Introduction to Web Development",
            "Web Dev Channel",
            480);

        video2.AddComment(new Comment(
            "David",
            "I learned a lot from this video."));

        video2.AddComment(new Comment(
            "Jessica",
            "The HTML explanation was great."));

        video2.AddComment(new Comment(
            "Daniel",
            "Looking forward to the next video."));

        Video video3 = new Video(
            "Understanding Git and GitHub",
            "Programming Tutorials",
            720);

        video3.AddComment(new Comment(
            "James",
            "Git finally makes sense to me."));

        video3.AddComment(new Comment(
            "Emily",
            "Thanks for the clear explanation."));

        video3.AddComment(new Comment(
            "Robert",
            "This helped me understand GitHub."));

        List<Video> videos = new List<Video>();

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}