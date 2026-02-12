using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaApod_App.Exceptions
{
    public class ApiKeyInvalidException : Exception
    {
        public ApiKeyInvalidException()
            : base("NASA API Key is invalid or unauthorized.")
        {
        }
    }
}
