using System;

namespace MusixmatchNet
{
    public class StatusCode
    {
        public static void CheckResponse(String response)
        {
            if (response.Contains("\"status_code\":400"))
                throw new StatusCodeException(400, "The request had bad syntax or was inherently impossible to be satisfied.");
            else if (response.Contains("\"status_code\":401"))
                throw new StatusCodeException(401, "Authentication failed, probably because of invalid/missing API key.");
            else if (response.Contains("\"status_code\":402"))
                throw new StatusCodeException(402, "The usage limit has been reached, either you exceeded per day requests limits or your balance is insufficient.");
            else if (response.Contains("\"status_code\":403"))
                throw new StatusCodeException(403, "You are not authorized to perform this operation.");
            else if (response.Contains("\"status_code\":404"))
                throw new StatusCodeException(404, "The requested resource was not found.");
            else if (response.Contains("\"status_code\":405"))
                throw new StatusCodeException(405, "The requested method was not found.");
            else if (response.Contains("\"status_code\":500"))
                throw new StatusCodeException(500, "Ops. Something were wrong.");
            else if (response.Contains("\"status_code\":503"))
                throw new StatusCodeException(503, "Our system is a bit busy at the moment and your request can�t be satisfied.");
        }
    }

    public class StatusCodeException : Exception
    {
        public StatusCodeException(int CODE, String OUTPUT)
             : base($"STATUS CODE {CODE} : {OUTPUT}")
        {
        }
    }
}