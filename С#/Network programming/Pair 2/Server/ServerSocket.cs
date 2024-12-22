using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CurrencyServer
{
    public class ServerSocket
    {
        private readonly IPEndPoint _endPoint;
        private readonly Socket _serverSocket;
        private readonly CurrencyRateService _currencyService;

        public ServerSocket(IPAddress ip, int port)
        {
            _endPoint = new IPEndPoint(ip, port);
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _currencyService = new CurrencyRateService();
        }

        public void Start()
        {
            _serverSocket.Bind(_endPoint);
            _serverSocket.Listen(10);
            Console.WriteLine($"Server started at {_endPoint}. Waiting for connections...");

            while (true)
            {
                var clientSocket = _serverSocket.Accept();
                Task.Run(() => HandleClient(clientSocket));
            }
        }

        private async Task HandleClient(Socket clientSocket)
        {
            var clientEndpoint = clientSocket.RemoteEndPoint.ToString();
            Console.WriteLine($"Client connected: {clientEndpoint} at {DateTime.Now}");

            try
            {
                using (clientSocket)
                {
                    byte[] buffer = new byte[1024];
                    while (true)
                    {
                        int bytesReceived = await clientSocket.ReceiveAsync(buffer, SocketFlags.None);
                        if (bytesReceived == 0) break;

                        string request = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                        Console.WriteLine($"Received from {clientEndpoint}: {request}");

                        string response = _currencyService.GetCurrencyRate(request);
                        byte[] responseBytes = Encoding.UTF8.GetBytes(response);

                        await clientSocket.SendAsync(responseBytes, SocketFlags.None);
                        Console.WriteLine($"Sent to {clientEndpoint}: {response}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with client {clientEndpoint}: {ex.Message}");
            }
            finally
            {
                Console.WriteLine($"Client disconnected: {clientEndpoint} at {DateTime.Now}");
            }
        }
    }
}
