using System;
using System.Collections.Generic;
using System.Text;

namespace BSMSShared.InputTypes
{
    // %Input postfix convention is used for add,update mutations.
    // DTOs don't work directly
    public class BookInput
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int AuthorId { get; set; }
    }
}
