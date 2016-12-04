using Discovery.iTextSharp.infrastructure.helper;
using Discovery.iTextSharp.models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Linq;

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
                document.ResetPageCount();

                AddMetaInformation(document);
                SetPageLayout(document);

                // set address
                var header = CreateDocumentHeader();
                document.Add(header);

                document.Add(new Paragraph(string.Empty));
                document.Add(new Paragraph(string.Empty));
                document.Add(new Paragraph(string.Empty));

                // set reason
                var reason = "Bill-No.: " + _bill.Number + " you bill from delivery: " + _bill.DeliveryNumber;
                document.Add(GetParagaph(reason));

                document.Add(new Paragraph(string.Empty));
                document.Add(new Paragraph(string.Empty));

                // set prices
                var priceTable = CreatePriceTable();
                document.Add(priceTable);

                document.Add(new Paragraph(string.Empty));
                document.Add(new Paragraph(string.Empty));


                // set info
                var info = "please pay at the nex 30 days!";
                document.Add(GetParagaph(info));
                document.Add(new Paragraph(string.Empty));

                // greetings

                var reg = "regardes";
                document.Add(GetParagaph(reg));
                var ppl = _bill.Date.ToShortDateString() + " " + _seller.Company.Location + " , " + _seller.Contacts.First().Name;
                document.Add(GetParagaph(ppl));

                document.Add(new Paragraph());

                // law

                document.Close();
            }


            return outputFile;
        }

        void SetPageLayout(Document document)
        {
            document.SetPageSize(PageSize.A4);
            document.SetMargins(20, 10, 10, 10);
        }

        PdfPTable CreateDocumentHeader()
        {
            var table = new PdfPTable(3);
            table.WidthPercentage = 100;

            table.AddCell(SmallSellerRow());
            AddRow(table, _bill.Customer.Company.Name, "contact");
            AddRow(table, _bill.Customer.Contacts.First().Name, _seller.Contacts.First().Name);
            AddRow(table, _bill.Customer.Company.Street, _seller.Contacts.First().Phone);
            AddRow(table, (_bill.Customer.Company.Postal + " " + _bill.Customer.Company.Location), _seller.Contacts.First().Mail);
            AddRow(table, _bill.Customer.Company.Country, string.Empty);

            return table;
        }

        PdfPTable CreatePriceTable()
        {
            var table = new PdfPTable(5);
            table.WidthPercentage = 100;

            AddPriceTableHeader(table);
            foreach (var article in _bill.Articles.ToList())
                AddArticleRow(table, article);

            AddEndRow(table, "sum", _totalPrice);
            AddEndRow(table, "tax", _totalTax);
            AddEndRow(table, "sum with tax", _totalPriceWithTax);

            return table;
        }


        decimal _totalPrice;
        decimal _totalTax;
        decimal _totalPriceWithTax;


        void AddRow(PdfPTable table, string firstPhrase, string secondPhrase)
        {
            var first = Layout.GetCell(1, BaseColor.WHITE);
            first.Phrase = new Phrase(firstPhrase) { Font = Layout.GetBaseFont() };
            table.AddCell(first);

            var second = Layout.GetCell(1, BaseColor.WHITE);
            second.Phrase = new Phrase(string.Empty) { Font = Layout.GetBaseFont() };
            table.AddCell(second);

            var third = Layout.GetCell(1, BaseColor.WHITE);
            third.Phrase = new Phrase(secondPhrase) { Font = Layout.GetBaseFont() };
            table.AddCell(third);
        }
        void AddArticleRow(PdfPTable table, Article article)
        {
            var first = Layout.GetCell(1, BaseColor.GRAY);
            first.Phrase = new Phrase(article.Number.ToString()) { Font = Layout.GetBaseFont() };
            table.AddCell(first);

            var second = Layout.GetCell(1, BaseColor.GRAY);
            second.Phrase = new Phrase(article.DisplayName) { Font = Layout.GetBaseFont() };
            table.AddCell(second);

            var third = Layout.GetCell(1, BaseColor.GRAY);
            third.Phrase = new Phrase(article.Amount.ToString()) { Font = Layout.GetBaseFont() };
            table.AddCell(third);

            var fourth = Layout.GetCell(1, BaseColor.GRAY);
            fourth.Phrase = new Phrase(article.Price.ToString()) { Font = Layout.GetBaseFont() };
            table.AddCell(fourth);

            var total = article.Amount * article.Price;
            var fifth = Layout.GetCell(1, BaseColor.GRAY);
            fifth.Phrase = new Phrase(total.ToString()) { Font = Layout.GetBaseFont() };
            table.AddCell(fifth);

            _totalPrice += total;
            var tax = (total / 100 * article.TaxInPercent);
            var priceWithTax = total + tax;
            _totalTax += tax;
            _totalPriceWithTax += priceWithTax;
        }

        void AddPriceTableHeader(PdfPTable table)
        {
            table.AddCell(Layout.GetHeaderCell("Art-No."));
            table.AddCell(Layout.GetHeaderCell("Article."));
            table.AddCell(Layout.GetHeaderCell("Amount"));
            table.AddCell(Layout.GetHeaderCell("Price"));
            table.AddCell(Layout.GetHeaderCell("Total Price"));
        }

        void AddEndRow(PdfPTable table, string content, decimal value)
        {
            var first = Layout.GetCell(1, BaseColor.GRAY);
            first.Phrase = new Phrase(string.Empty) { Font = Layout.GetBaseFont() };
            table.AddCell(first);

            var second = Layout.GetCell(1, BaseColor.GRAY);
            second.Phrase = new Phrase(content) { Font = Layout.GetBaseFont() };
            table.AddCell(second);

            var third = Layout.GetCell(1, BaseColor.GRAY);
            third.Phrase = new Phrase(string.Empty) { Font = Layout.GetBaseFont() };
            table.AddCell(third);

            var fourth = Layout.GetCell(1, BaseColor.GRAY);
            fourth.Phrase = new Phrase(string.Empty) { Font = Layout.GetBaseFont() };
            table.AddCell(fourth);

            var fifth = Layout.GetCell(1, BaseColor.GRAY);
            fifth.Phrase = new Phrase(value.ToString()) { Font = Layout.GetBaseFont() };
            table.AddCell(fifth);
        }

        Paragraph GetParagaph(string content)
        {
            var p = new Paragraph(content)
            {
                Font = Layout.GetBaseFont(),
                Alignment = Element.ALIGN_LEFT
            };

            return p;
        }


        PdfPCell SmallSellerRow()
        {
            var sellerPhrase = _seller.Company.Name + " - " + _seller.Company.Street + " " + _seller.Company.Postal + " " + _seller.Company.Location + " " + _seller.Company.Country;
            return Layout.GetSmallesCell(sellerPhrase);
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
