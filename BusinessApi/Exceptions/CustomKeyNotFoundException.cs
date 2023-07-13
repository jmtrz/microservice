using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApi.Exceptions;

public class CustomkeyNotFoundException : Exception
{
    // public CustomkeyNotFoundException(string msg) : base(msg) { }

    public const HttpStatusCode HTTPCODE = HttpStatusCode.NotFound;
    
    public static string ProblemResultDetails(Exception ex)
    {        
        ProblemDetails problem = new()
        {
            Status = (int)HttpStatusCode.InternalServerError,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.2",
            Title = "ID Not Found in the Database",
            Detail = ex.Message
        };
        return JsonSerializer.Serialize(problem);  
    }
}