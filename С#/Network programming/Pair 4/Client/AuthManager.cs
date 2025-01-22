using System;
using System.Text;
using System.Net.Sockets;
using Pair4.Shared;

namespace Pair4.Client
{
    public class AuthManager
    {
        private readonly TcpClient _client;

        public AuthManager(TcpClient client)
        {
            _client = client;
        }

        public bool Register(string username, string password)
        {
            string request = Protocol.CreateRequest(Protocol.RequestType.Register, $"{username}:{password}");
            return SendRequest(request);
        }

        public bool Login(string username, string password)
        {
            string request = Protocol.CreateRequest(Protocol.RequestType.Login, $"{username}:{password}");
            return SendRequest(request);
        }

        private bool SendRequest(string request)
        {
            var stream = _client.GetStream();
            byte[] data = Encoding.UTF8.GetBytes(request);
            stream.Write(data, 0, data.Length);

            byte[] buffer = new byte[1024];
            int length = stream.Read(buffer, 0, buffer.Length);
            string response = Encoding.UTF8.GetString(buffer, 0, length);

            return Protocol.IsSuccess(response);
        }
    }
}
