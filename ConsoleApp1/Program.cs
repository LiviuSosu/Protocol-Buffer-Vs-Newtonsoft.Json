using Google.Protobuf;
using Google.Protobuf.Examples.AddressBook;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using static Google.Protobuf.Examples.AddressBook.Books.Types;
using static Google.Protobuf.Examples.AddressBook.Books.Types.BookInfo.Types;

namespace ConsoleApp1
{
    class Program
    {
        const string jsonDataFile = "ProtobuffVsJson.Data.data.json";
        const string protoDataFile = "ProtobuffVsJson.Data.data.dat";

        static void Main(string[] args)
        {
            int dataSize = 100000;

            SerializeProtoBuff(dataSize);
            Console.WriteLine("Finished! protobuf");
            SerializeJson(dataSize);
            Console.WriteLine("Finished! json");
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
                    Description = (i*i).ToString()
                };

                books.Books_.Add(bookInfo);
            }

            var sw = new Stopwatch();
            sw.Start();

            var assembly = Assembly.GetExecutingAssembly();

            using (var output = File.Create(protoDataFile))
            {
                books.WriteTo(output);
            }

            using (var input = File.OpenRead(protoDataFile))
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
                    PageCount = i,
                    
                };

                books.Add(bookInfo);
            }

            var sw = new Stopwatch();
            sw.Start();

            File.WriteAllText(jsonDataFile, JsonConvert.SerializeObject(books));

            var assembly = Assembly.GetExecutingAssembly();
       
            using (Stream stream = assembly.GetManifestResourceStream(jsonDataFile))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
            }

            books = JsonConvert.DeserializeObject<List<BookInfoJson>>(File.ReadAllText(jsonDataFile));
            sw.Stop();
            long elapsedMilliseconds = sw.ElapsedMilliseconds;
        }
    }
}
