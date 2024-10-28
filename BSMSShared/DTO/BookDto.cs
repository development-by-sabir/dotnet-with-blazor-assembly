using BSMSShared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSMSShared.DTO
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
