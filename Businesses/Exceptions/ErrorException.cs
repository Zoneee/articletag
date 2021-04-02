﻿using System;

namespace Businesses.Exceptions
{
    public class ErrorException : Exception
    {
        public ErrorException(string message) : base(message)
        {
        }

        public ErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
