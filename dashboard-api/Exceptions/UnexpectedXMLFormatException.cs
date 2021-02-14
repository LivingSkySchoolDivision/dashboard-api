using System;
using System.Collections.Generic;
using System.Text;

namespace dashboard_api
{
    public class UnexpectedXMLFormatException : Exception
    {
        public UnexpectedXMLFormatException() : base() { }
        public UnexpectedXMLFormatException(string message) : base(message) { }
        public UnexpectedXMLFormatException(string message, Exception innerException) : base(message, innerException) { }
    }
}
