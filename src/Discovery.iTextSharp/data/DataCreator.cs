using Discovery.iTextSharp.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Discovery.iTextSharp.data
{
    internal static class DataCreator
    {
        internal static void CreateSeller()
        {
            var seller = new Customer
            {
                Company = new BaseAddress
                {
                    Number = 0,
                    Name = "Coffeenation GmbH",
                    Website = "www.coffeenation.de",
                    Mail = "info@coffeenation.de",
                    Phone = "0309695320",
                    Country = "Germany",
                    Postal = "17541",
                    Street = "Thortauer Ring 4",
                    Location = "Berlin"
                },
                Contacts = new List<BaseAddress>
                {
                    new BaseAddress
                    {
                        Number = -1,
                        Name = "Constanze Fogt",
                        Website = "www.coffeenation.de",
                        Mail = "c.fogt@coffeenation.de",
                        Phone = "0309695317",
                        Country = "Germany",
                        Postal = "17541",
                        Street = "Thortauer Ring 4",
                        Location = "Berlin"
                    }
                }
            };

            var filePath = Path.Combine(GetDirectory(), "seller-0.json");
            var content = JsonConvert.SerializeObject(seller);
            SaveFile(filePath, content);
        }

        internal static void CreateBill()
        {
            var bill = new Bill
            {
                Number = 98142,
                Date = DateTime.Now,
                Articles = CreateArticles(),
                Customer = CreateCustomer(),
                DeliveryNumber = 2345
            };

            var filePath = Path.Combine(GetDirectory(), "bill-98142.json");
            var content = JsonConvert.SerializeObject(bill);
            SaveFile(filePath, content);
        }

        static void SaveFile(string filename, string content)
        {
            if (File.Exists(filename))
                File.Delete(filename);

            File.WriteAllText(filename, content);
        }

        static string GetDirectory()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
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
                Contacts = new List<BaseAddress>
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
                }
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
