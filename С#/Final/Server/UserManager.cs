using System;
using System.Collections.Generic;
using Pair4.Shared;

namespace Pair4.Server
{
    public class UserManager
    {
        private readonly Dictionary<string, string> _users = new();

        public string Register(string credentials)
        {
            var parts = credentials.Split(':');
            if (parts.Length != 2) return Protocol.CreateErrorResponse("Invalid credentials format.");

            string username = parts[0];
            string password = parts[1];

            if (_users.ContainsKey(username))
            {
                return Protocol.CreateErrorResponse("Username already exists.");
            }

            _users[username] = password;
            return Protocol.CreateSuccessResponse("Registration successful.");
        }

        public string Login(string credentials)
        {
            var parts = credentials.Split(':');
            if (parts.Length != 2) return Protocol.CreateErrorResponse("Invalid credentials format.");

            string username = parts[0];
            string password = parts[1];

            if (_users.TryGetValue(username, out var storedPassword) && storedPassword == password)
            {
                return Protocol.CreateSuccessResponse("Login successful.");
            }

            return Protocol.CreateErrorResponse("Invalid username or password.");
        }
    }
}
