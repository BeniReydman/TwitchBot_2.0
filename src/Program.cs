using System;

namespace TwitchBot
{
    class Program
    {
        static void Main(string[] args)
        {
            IrcClient client = new IrcClient("irc.twitch.tv", 6667, "ninjamonkersbot", System.IO.File.ReadAllText(@"Password.txt"), "ninjamonkers");

            // Send ping every 5 minutes
            var pinger = new Pinger(client);
            pinger.Start();

            // Send chat message via console
            var consoleChat = new ConsoleChat(client);
            consoleChat.Start();

            while (true)
            {
                Console.WriteLine("Reading message");
                var message = client.ReadMessage();
                Console.WriteLine($"Message: {message}");
            }
        }
    }
}