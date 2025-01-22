using System;
using System.IO;
using Pair4.Shared;

namespace Pair4.Server
{
    public class FileManager
    {
        private readonly string _storagePath = "ReceivedFiles";

        public FileManager()
        {
            if (!Directory.Exists(_storagePath))
            {
                Directory.CreateDirectory(_storagePath);
            }
        }

        public string SaveFile(string fileName, byte[] fileData)
        {
            try
            {
                string filePath = Path.Combine(_storagePath, fileName);
                File.WriteAllBytes(filePath, fileData);
                return Protocol.CreateSuccessResponse($"File '{fileName}' saved successfully.");
            }
            catch (Exception ex)
            {
                return Protocol.CreateErrorResponse($"Failed to save file: {ex.Message}");
            }
        }
    }
}
