using System;
using System.Collections.Generic;
using Pair4.Shared;

namespace Pair4.Server
{
    public class ChatManager
    {
        private readonly List<string> _chatHistory = new();

        public string HandleMessage(string message)
        {
            _chatHistory.Add(message);
            return Protocol.CreateSuccessResponse($"Message received: {message}");
        }

        public IEnumerable<string> GetChatHistory()
        {
            return _chatHistory;
        }
    }
}
