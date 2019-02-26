using Google.Protobuf;
using Google.Protobuf.Examples.AddressBook;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static Google.Protobuf.Examples.AddressBook.Books.Types;
using static Google.Protobuf.Examples.AddressBook.Books.Types.BookInfo.Types;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int dataSize = 100000;
            //SerializeProtoBuff(dataSize);
            SerializeJson(dataSize);

            Console.WriteLine("Finished!");
            Console.ReadKey();
        }

        private static void SerializeProtoBuff(int dataSize)
        {
            BookInfo bookInfo;
            Books books = new Books();
            //generating data
            for (int i = 1; i <= dataSize; i++)
            {
                bookInfo = new BookInfo
                {
                    Id = i,
                    Author = new Author() { Name = "Author name " + i },
                    Title = "Title " + i,
                    PageCount = i,
                };

                books.Books_.Add(bookInfo);
            }

            var sw = new Stopwatch();
            sw.Start();

            //make sure to adapt file path in order to work properly
            string fileName = @"C:\Users\lsosu\Work\Protobuf\ConsoleApp1\ConsoleApp1\data.dat";

            using (var output = File.Create(fileName))
            {
                books.WriteTo(output);
            }

            using (var input = File.OpenRead(fileName))
            {
                books = Books.Parser.ParseFrom(input);
            }
            sw.Stop();
            long elapsedMilliseconds = sw.ElapsedMilliseconds;
        }

        private static void SerializeJson(int dataSize)
        {
            BookInfoJson bookInfo;
            var books = new List<BookInfoJson>();

            //generating data
            for (int i = 1; i <= dataSize; i++)
            {
                bookInfo = new BookInfoJson
                {
                    Id = i,
                    Author = new AuthorJson() { Name = "Author name " + i },
                    Title = "Title " + i,
                    PageCount = i
                };

                books.Add(bookInfo);
            }

            var sw = new Stopwatch();
            sw.Start();

            //make sure to adapt file path in order to work properly
            string fileName = @"C:\Users\lsosu\Work\Protobuf\ConsoleApp1\ConsoleApp1\data.json";

            File.WriteAllText(fileName, JsonConvert.SerializeObject(books));

            books = JsonConvert.DeserializeObject<List<BookInfoJson>>(File.ReadAllText(fileName));
            sw.Stop();
            long elapsedMilliseconds = sw.ElapsedMilliseconds;
        }
    }
}
