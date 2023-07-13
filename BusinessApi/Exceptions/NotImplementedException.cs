
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApi.Exceptions;

public class NotImplementedException : Exception
{
    public const HttpStatusCode HTTPCODE = HttpStatusCode.NotFound;
    public NotImplementedException(string msg) : base(msg) { }
    public static string ProblemResultDetails(Exception ex)
    {        
        ProblemDetails problem = new()
        {
           Status = (int)HttpStatusCode.NotImplemented,
           Type = "https://tools.ietf.org/html/rfc7231#section-6.6.2",
           Title = ex.Message,
           Detail = ex.StackTrace
        };
        return JsonSerializer.Serialize(problem);  
    }
}