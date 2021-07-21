using System;
using System.Threading;

namespace TwitchBot
{
    public class ConsoleChat
    {
        private IrcClient client;
        private Thread sender;

        public ConsoleChat(IrcClient client)
        {
            this.client = client;
            sender = new Thread(new ThreadStart(Run));
        }

        public void Start()
        {
            sender.IsBackground = true;
            sender.Start();
        }

        private void Run()
        {
            while(true)
            {
                Console.WriteLine("Waiting for console message");
                string message = Console.ReadLine();
                Console.WriteLine($"Received console message: {message}");
                client.SendChatMessage(message);
                Console.WriteLine("Sent console message");
            }
        }
    }
}
