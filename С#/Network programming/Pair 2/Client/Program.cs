using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CurrencyClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter server IP:");
            string serverIP = Console.ReadLine() ?? "127.0.0.1";

            Console.WriteLine("Enter server port:");
            int serverPort = int.Parse(Console.ReadLine() ?? "8080");

            IPAddress ip = IPAddress.Parse(serverIP);
            EndPoint serverEndpoint = new IPEndPoint(ip, serverPort);

            using var clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                clientSocket.Connect(serverEndpoint);
                Console.WriteLine($"Connected to server at {serverEndpoint}.");

                while (true)
                {
                    Console.Write("Enter currencies (e.g., USD EURO) or 'exit': ");
                    string message = Console.ReadLine();

                    if (message?.ToLower() == "exit") break;

                    byte[] requestBytes = Encoding.UTF8.GetBytes(message);
                    clientSocket.Send(requestBytes);

                    byte[] responseBuffer = new byte[1024];
                    int responseLength = clientSocket.Receive(responseBuffer);

                    string response = Encoding.UTF8.GetString(responseBuffer, 0, responseLength);
                    Console.WriteLine($"Server response: {response}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
