using Discovery.iTextSharp.models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace Discovery.iTextSharp.infrastructure.helper
{
    internal static class FileManager
    {
        internal static Customer GetSeller(string filename)
        {
            CheckFile(filename);
            var content = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<Customer>(content);
        }

        internal static Bill GetBill(string filename)
        {
            CheckFile(filename);
            var content = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<Bill>(content);
        }

        internal static string GetFilesDirectory()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
        }

        internal static string GetFilename(string part)
        {
            var dirInfo = new DirectoryInfo(GetFilesDirectory());
            var possibleFileInfos = dirInfo.EnumerateFiles("*.json");
            var fileInfo = possibleFileInfos.FirstOrDefault(n => n.Name.Contains(part));

            if (fileInfo == null)
                throw new FileNotFoundException("there is no file");

            return fileInfo.FullName;
        }

        static bool CheckFile(string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException("there is no " + filename);
            return true;
        }
    }
}
