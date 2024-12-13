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

            Console.WriteLine("Сервер запущено. Очікування клієнтів...");

            while (true)
            {
                Socket clientSocket = serverSocket.Accept();
                var clientEndPoint = clientSocket.RemoteEndPoint;

                Console.WriteLine($"Клієнт {clientEndPoint} підключився.");

                byte[] buffer = new byte[1024];
                int receivedBytes = clientSocket.Receive(buffer);
                string clientMessage = Encoding.UTF8.GetString(buffer, 0, receivedBytes);

                Console.WriteLine($"О {DateTime.Now:HH:mm} від {clientEndPoint} отримано рядок: {clientMessage}");

                string serverMessage = "Привіт, клієнте!";
                byte[] responseBytes = Encoding.UTF8.GetBytes(serverMessage);
                clientSocket.Send(responseBytes);

                Console.WriteLine($"О {DateTime.Now:HH:mm} повідомлення відправлено клієнту: {serverMessage}");

                clientSocket.Close();
            }
        }
    }
}
