using Discovery.iTextSharp.data;
using System;
using System.IO;
using System.Linq;

namespace Discovery.iTextSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckExistingFiles();

            Console.WriteLine("done");
            Console.ReadKey();
        }

        static void CheckExistingFiles()
        {
            Console.WriteLine("check for existing files");
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
            var filenames = new DirectoryInfo(path).EnumerateFiles("*.json");

            if (filenames != null && filenames.Any())
            {
                Console.WriteLine("files found ({0})", filenames.Count());
                return;
            }

            Console.WriteLine("create files");
            DataCreator.CreateSeller();
            DataCreator.CreateBill();
        }
    }
}
