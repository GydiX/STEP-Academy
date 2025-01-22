using System;

namespace Pair4.Shared
{
    public static class Protocol
    {
        public enum RequestType
        {
            Register,
            Login,
            Message,
            File
        }

        public static string CreateRequest(RequestType type, string data)
        {
            return $"{type}:{data}";
        }

        public static string ParseRequest(string message)
        {
            return message.Contains(":") ? message : null;
        }

        public static string CreateSuccessResponse(string message)
        {
            return $"Success:{message}";
        }

        public static string CreateErrorResponse(string message)
        {
            return $"Error:{message}";
        }

        public static bool IsSuccess(string response)
        {
            return response.StartsWith("Success:");
        }
    }
}
