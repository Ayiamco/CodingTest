using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coding_Test.Dtos
{
    public class ResponseDto<T>
    {
        public int status { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
}
