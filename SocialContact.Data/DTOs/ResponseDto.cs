using System;
using System.Collections.Generic;
using System.Text;

namespace SocialContact.Data.DTOs
{
    public class ResponseDto<T>
    {
        public Dictionary<string, string> Errs { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}
