using Discovery.iTextSharp.infrastructure.helper;
using Discovery.iTextSharp.models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;

namespace Discovery.iTextSharp.infrastructure
{
    internal class PdfCreator
    {
        Customer _seller = new Customer();
        Bill _bill = new Bill();

        internal PdfCreator(string filenameSeller, string filenameBill)
        {
            _seller = FileManager.GetSeller(filenameSeller);
            _bill = FileManager.GetBill(filenameBill);
        }

        internal string CreateBillPdf()
        {
            var outputFile = Path.Combine(FileManager.GetFilesDirectory(), "output.pdf");

            using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None))
            using (Document document = new Document())
            using (PdfWriter writer = PdfWriter.GetInstance(document, fs))
            {
                document.Open();
                AddMetaInformation(document);
                SetPageLayout(document);

                var table = CreateDocuemntHeader();
                document.Add(table);

                document.Add(new Paragraph("Hi! I'm Original"));
                document.Close();
            }


            return outputFile;
        }

        private void SetPageLayout(Document document)
        {
            document.SetPageSize(PageSize.A4);
            document.SetMargins(20, 10, 10, 10);
        }

        PdfPTable CreateDocuemntHeader()
        {
            var table = new PdfPTable(3);

            var sellerPhrase = _seller.Company.Name + " - " + _seller.Company.Street + " " + _seller.Company.Postal + " " + _seller.Company.Location + " " + _seller.Company.Country;
            var sellerCell = new PdfPCell
            {
                Colspan = 1,
                HorizontalAlignment = 1,
                Phrase = new Phrase(sellerPhrase) { Font = Layout.GetSmallestFont() },
                VerticalAlignment = 1
            };
            table.AddCell(sellerCell);

            var firstLeft = new PdfPCell
            {
                Colspan = 1,
                HorizontalAlignment = 1,
                Phrase = new Phrase(_bill.Customer.Company.Name) { Font = Layout.GetBaseFont() },
                VerticalAlignment = 1
            };
            table.AddCell(firstLeft);

            var secondLeft = new PdfPCell
            {
                Colspan = 1,
                HorizontalAlignment = 1,
                Phrase = new Phrase(_bill.Customer.Company.Street) { Font = Layout.GetBaseFont() },
                VerticalAlignment = 1
            };
            table.AddCell(secondLeft);

            var thirdLeft = new PdfPCell
            {
                Colspan = 1,
                HorizontalAlignment = 1,
                Phrase = new Phrase(_bill.Customer.Company.Postal + " " + _bill.Customer.Company.Location) { Font = Layout.GetBaseFont() },
                VerticalAlignment = 1
            };
            table.AddCell(thirdLeft);


            for (int i = 0; i < 10; i++)
                table.AddCell(string.Format(DateTime.Now.Ticks.ToString()));

            return table;
        }

        void AddMetaInformation(Document document)
        {
            document.AddAuthor(Environment.UserName);
            document.AddCreator(Environment.MachineName);
            document.AddKeywords("pdf, creation, itextsharp, tryout, discovery");
            document.AddSubject("create a easy bill");
            document.AddTitle("Bill");
        }
    }
}
