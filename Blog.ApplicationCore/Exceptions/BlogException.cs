using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.ApplicationCore.Exceptions
{
    public class BlogException : Exception
    {
        public BlogException(string message) : base(message) {
        }
    }
}
