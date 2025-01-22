using System;
using System.Net.Sockets;
using System.Text;
using Pair4.Shared;

namespace Pair4.Client
{
    public class ClientApp
    {
        private TcpClient _client;
        private const string ServerAddress = "127.0.0.1";
        private const int ServerPort = 8080;

        public void Run()
        {
            _client = new TcpClient(ServerAddress, ServerPort);
            Console.WriteLine("Connected to server.");

            while (true)
            {
                Console.Write("Enter message (or 'exit' to quit): ");
                string message = Console.ReadLine();
                if (message == "exit") break;

                SendMessage(message);
                string response = ReceiveMessage();
                Console.WriteLine($"Server: {response}");
            }

            _client.Close();
        }

        private void SendMessage(string message)
        {
            var stream = _client.GetStream();
            byte[] data = Encoding.UTF8.GetBytes(message);
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
