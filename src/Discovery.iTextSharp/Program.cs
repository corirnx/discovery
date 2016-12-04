using Discovery.iTextSharp.data;
using Discovery.iTextSharp.infrastructure;
using Discovery.iTextSharp.infrastructure.helper;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Discovery.iTextSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckExistingFiles();

            var seller = FileManager.GetFilename("seller");
            var bill = FileManager.GetFilename("bill");

            Console.WriteLine("create bill pdf");
            var pdfcreator = new PdfCreator(seller, bill);
            var pdfFilename = pdfcreator.CreateBillPdf();
            Console.WriteLine("done");

            Process.Start(pdfFilename);
            Console.ReadKey();
        }

        static void CheckExistingFiles()
        {
            Console.WriteLine("check for existing files");
            var path = FileManager.GetFilesDirectory();
            var filenames = new DirectoryInfo(path).EnumerateFiles("*.json");

            if (filenames != null && filenames.Count() > 1)
            {
                Console.WriteLine("files found ({0})", filenames.Count());
                return;
            }

            Console.WriteLine("create files");
            DataCreator.CreateSeller();
            DataCreator.CreateBill();
            Console.WriteLine("done");
        }
    }
}
