using System;
using System.IO;
using System.Net.Sockets;
using Pair4.Shared;

namespace Pair4.Client
{
    public class FileTransfer
    {
        private readonly TcpClient _client;

        public FileTransfer(TcpClient client)
        {
            _client = client;
        }

        public void SendFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                return;
            }

            byte[] fileData = File.ReadAllBytes(filePath);
            string fileName = Path.GetFileName(filePath);
            string header = Protocol.CreateRequest(Protocol.RequestType.File, fileName);
            SendData(header, fileData);
            Console.WriteLine("File sent successfully.");
        }

        private void SendData(string header, byte[] fileData)
        {
            var stream = _client.GetStream();
            byte[] headerData = Encoding.UTF8.GetBytes(header);
            stream.Write(headerData, 0, headerData.Length);

            stream.Write(fileData, 0, fileData.Length);
        }
    }
}
