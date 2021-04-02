using System;
using System.Collections.Generic;
using System.Text;

namespace Businesses.Exceptions
{
    public class WarnException : Exception
    {
        public WarnException(string message) : base(message)
        {
        }

        public WarnException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
