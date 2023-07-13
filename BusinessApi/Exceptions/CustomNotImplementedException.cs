
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApi.Exceptions;

public class CustomNotImplementedException : Exception
{
    // public CustomNotImplementedException(string msg) : base(msg) { }

    public const HttpStatusCode HTTPCODE = HttpStatusCode.NotFound;
    
    public static string ProblemResultDetails()
    {        
        ProblemDetails problem = new()
        {
           Status = (int)HttpStatusCode.NotImplemented,
           Type = "https://tools.ietf.org/html/rfc7231#section-6.6.2",
           Title = "ID Not Found in the Database",
           Detail = "The server does not support the request method for the request-uri resource."
        };
        return JsonSerializer.Serialize(problem);  
    }
   
}