using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class BookInfoJson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }

        public AuthorJson Author { get; set; }
    }

    class AuthorJson
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
