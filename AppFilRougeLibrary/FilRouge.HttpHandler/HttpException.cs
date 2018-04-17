using System;
using System.Collections.Generic;
using System.Text;

namespace FilRouge.HttpHandler
{
    class ExceptionLogin : Exception
    {
        private string _message;
        public ExceptionLogin(string message)
            : base("message")
        {
            this._message = message;
        }
    }
}
