using System.Net;
using System.Text;

namespace CurrencyServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int port = 8080;
            IPAddress ip = IPAddress.Parse(127.0.0.1);

            Console.WriteLine(Starting Currency Server...);
            ServerSocket server = new ServerSocket(ip, port);
            server.Start();
        }
    }
}
