using System;
using System.Net.Sockets;
using System.Text;
using Pair4.Shared;

namespace Pair4.Client
{
    public class ChatSession
    {
        private readonly TcpClient _client;

        public ChatSession(TcpClient client)
        {
            _client = client;
        }

        public void Start()
        {
            Console.WriteLine("Chat session started. Type 'exit' to leave.");
            while (true)
            {
                Console.Write("You: ");
                string message = Console.ReadLine();
                if (message == "exit") break;

                SendMessage(message);
                string response = ReceiveMessage();
                Console.WriteLine($"Server: {response}");
            }
        }

        private void SendMessage(string message)
        {
            var stream = _client.GetStream();
            string request = Protocol.CreateRequest(Protocol.RequestType.Message, message);
            byte[] data = Encoding.UTF8.GetBytes(request);
            stream.Write(data, 0, data.Length);
        }

        private string ReceiveMessage()
        {
            var stream = _client.GetStream();
            var buffer = new byte[1024];
            int length = stream.Read(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer, 0, length);
        }
    }
}
