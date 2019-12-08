using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace featherink.Models
{
    public class ErrorResponseModel
    {
        public ErrorResponseModel(string error)
        {
            Error = error;
        }

        public string Error { get; }
    }
}
