using System;
using System.Collections.Generic;
using System.Text;

namespace BSMSShared.DTO
{
    public class AuthorsQueryReponse
    {
        public List<AuthorDto> Authors { get; set; }
    }

    public class AuthorQueryReponse
    {
        public AuthorDto Author { get; set; }
    }

    public class AuthorByIdQueryReponse
    {
        public AuthorDto AuthorById { get; set; }
    }
}
