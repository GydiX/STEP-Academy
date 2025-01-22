using System.IO;

namespace Pair4.Shared
{
    public static class Utils
    {
        public static string ComputeFileChecksum(string filePath)
        {
            using var stream = File.OpenRead(filePath);
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            byte[] hash = sha256.ComputeHash(stream);
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }
    }
}
