using System;
using System.Collections.Generic;
using System.Text;

namespace BSMSShared.DTO
{
    public class BooksQueryResponse
    {
        public List<BookDto> Books { get; set; }
    }

    public class BookQueryResponse
    {
        public BookDto Book { get; set; }
    }

    public class BookByIdQueryResponse
    {
        // Same name as mentioned in Query i.e. bookById(id: $id)
        public BookDto BookById { get; set; }
    }
}
