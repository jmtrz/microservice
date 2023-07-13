using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApi.Exceptions;

public class BadRequestException : Exception
{
    public const HttpStatusCode HTTPCODE = HttpStatusCode.BadRequest;
    public BadRequestException(string msg) : base(msg) { }
    public static string ProblemResultDetails(Exception ex)
    {        
        ProblemDetails problem = new()
        {
            Status = (int)HttpStatusCode.InternalServerError,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.2",
            Title = ex.Message,
            Detail = ex.StackTrace
        };
        return JsonSerializer.Serialize(problem);  
    }
}