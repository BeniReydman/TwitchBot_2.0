using System;

namespace TwitchBot
{
    class Program
    {
        static void Main(string[] args)
        {
            IrcClient client = new IrcClient("irc.twitch.tv", 6667, "NinjaMonkersBot", System.IO.File.ReadAllText(@"Password.txt"), "ninjamonkers");

            var pinger = new Pinger(client);
            pinger.Start();

            client.SendChatMessage("Guess who's back Joe >:)");

            while (true)
            {
                Console.WriteLine("Reading message");
                var message = client.ReadMessage();
                Console.WriteLine($"Message: {message}");
            }
        }
    }
}