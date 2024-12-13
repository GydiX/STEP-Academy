using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int port = 1024;
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(ip, port);

            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(endPoint);
            serverSocket.Listen();

            Console.WriteLine("Сервер запущено. Очікування запитів...");

            while (true)
            {
                Socket clientSocket = serverSocket.Accept();
                Console.WriteLine($"Клієнт {clientSocket.RemoteEndPoint} підключився.");

                byte[] buffer = new byte[1024];
                int receivedBytes = clientSocket.Receive(buffer);
                string clientRequest = Encoding.UTF8.GetString(buffer, 0, receivedBytes).ToLower();

                string response = clientRequest switch
                {
                    "дата" => DateTime.Now.ToShortDateString(),
                    "час" => DateTime.Now.ToLongTimeString(),
                    _ => "Невідомий запит."
                };

                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                clientSocket.Send(responseBytes);

                Console.WriteLine($"Відправлено: {response}");
                clientSocket.Close();
            }
        }
    }
}
