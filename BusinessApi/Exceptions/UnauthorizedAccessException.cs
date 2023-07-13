using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApi.Exceptions;

public class UnauthorizedAccessException : Exception
{
    public const HttpStatusCode HTTPCODE = HttpStatusCode.Unauthorized;
    public UnauthorizedAccessException(string msg) : base(msg) { }
    public static string ProblemResultDetails(Exception ex)
    {        
        ProblemDetails problem = new()
        {
           Status = (int)HttpStatusCode.Unauthorized,
           Type = "https://tools.ietf.org/html/rfc7231#section-6.6.2",
           Title = ex.Message,
           Detail = ex.StackTrace
        };
        return JsonSerializer.Serialize(problem);  
    }
}