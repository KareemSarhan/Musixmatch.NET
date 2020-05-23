using System;
using System.Collections.Generic;
using System.Text;
namespace MusixmatchNet { 
    public class StatusCodeException : Exception
    {
        public StatusCodeException(int CODE,String OUTPUT)
            : base($"STATUS CODE {CODE} : {OUTPUT}")
        {
        }
    }
}
