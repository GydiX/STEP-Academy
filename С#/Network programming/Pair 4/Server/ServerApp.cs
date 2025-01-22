using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Pair4.Shared;

namespace Pair4.Server
{
    public class ServerApp
    {
        private const int Port = 8080;
        private TcpListener _listener;
        private readonly UserManager _userManager = new UserManager();
        private readonly ChatManager _chatManager = new ChatManager();

        public void Start()
        {
            _listener = new TcpListener(IPAddress.Any, Port);
            _listener.Start();
            Console.WriteLine($"Server started on port {Port}.");

            while (true)
            {
                var client = _listener.AcceptTcpClient();
                Console.WriteLine($"New client connected from {((IPEndPoint)client.Client.RemoteEndPoint).Address}");

                var clientHandler = new ClientHandler(client, _userManager, _chatManager);
                clientHandler.HandleClientAsync();
            }
        }
    }

    internal class ClientHandler
    {
        private readonly TcpClient _client;
        private readonly UserManager _userManager;
        private readonly ChatManager _chatManager;

        public ClientHandler(TcpClient client, UserManager userManager, ChatManager chatManager)
        {
            _client = client;
            _userManager = userManager;
            _chatManager = chatManager;
        }

        public async void HandleClientAsync()
        {
            using var stream = _client.GetStream();
            var buffer = new byte[1024];

            while (_client.Connected)
            {
                int length = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (length == 0) break;

                string message = Encoding.UTF8.GetString(buffer, 0, length);
                var response = ProcessMessag
