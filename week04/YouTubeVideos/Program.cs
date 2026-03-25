using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video();
        video1._title = "Jugando Clash Royale 2026";
        video1._author = "thegrefg";
        video1._length = 1059;
        video1._comments.Add(new Comment("David","buen video grefg"));
        video1._comments.Add(new Comment("Agustin","sube el mega al 16"));
        video1._comments.Add(new Comment("Vicente","ya hacia falta probar el modo caos"));


        Video video2 = new Video();
        video2._title = "Fortnite Highlights";
        video2._author = "Ninja";
        video2._length = 300;
        video2._comments.Add(new Comment("Tfue","you are mastering your building skills"));
        video2._comments.Add(new Comment("NoobMaster69","the pump damage is crazy"));
        video2._comments.Add(new Comment("Bugha","I miss Halo videos"));


        Video video3 = new Video();
        video3._title = "Israel Adesanya vs Alex Pereira 2";
        video3._author = "ufc";
        video3._length = 1500;
        video3._comments.Add(new Comment("Sean","Izzy is back!"));
        video3._comments.Add(new Comment("Conor","What a fight"));
        video3._comments.Add(new Comment("Ilia","These guys have the best rivalry in ufc"));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length}");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");

            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"{comment._name}: {comment._text}");
            }

            Console.WriteLine("------------------------------");

        }
    }
}