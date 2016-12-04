using Discovery.iTextSharp.models;
using System;
using System.Collections.Generic;

namespace Discovery.iTextSharp.data
{
    internal static class DataCreator
    {
        internal static void CreateBill()
        {
            var bill = new Bill();
            bill.Articles = CreateArticles();
            bill.Customer = CreateCustomer();
            bill.Date = DateTime.Now;
            bill.Number = 98142;
        }

        static Customer CreateCustomer()
        {
            var customer = new Customer
            {
                Company = new BaseAddress()
                {
                    Number = 19657,
                    Name = "Sunny Sunshine GmbH",
                    Website = "www.sunny-sunshine.de",
                    Mail = "info@ssunshine.de",
                    Phone = "0307235539",
                    Country = "Germany",
                    Postal = "10696",
                    Street = "Franz-Josef Strasse 47",
                    Location = "Berlin"
                },
                Contacts = new List<IAddress>
                {
                    new BaseAddress
                    {
                        Number = 19750,
                        Name = "Peter Morsig",
                        Website = "www.smiling-sunshine.de",
                        Mail = "p.morsig@ssunshine.de",
                        Phone = "0307235510",
                        Country = "Germany",
                        Postal = "10696",
                        Street = "Franz-Josef Strasse 47",
                        Location = "Berlin"
                    }
                },

            };

            return customer;
        }

        static IEnumerable<Article> CreateArticles()
        {
            var articles = new List<Article>
            {
                new Article
                {
                    Number = 18,
                    DisplayName = "BLASERCAFÉ LILLA E ROSE, 1 KG",
                    Producer = "BLASER Café AG",
                    Price = 20,
                    Amount = 5,
                    TaxInPercent = 19
                },
                new Article
                {
                    Number = 12,
                    DisplayName = "VICCI ROT, 0,5 KG",
                    Producer = "pajdakovic & müller gbr",
                    Price = 8,
                    Amount = 12,
                    TaxInPercent = 19
                },

                new Article
                {
                    Number = 7,
                    DisplayName = "IZZO SILVER DOSE, 3 KG",
                    Producer = " Gruppo Izzo srl, Via Morolense",
                    Price = 60,
                    Amount = 3,
                    TaxInPercent = 19
                },

            };

            return articles;
        }

    }
}
