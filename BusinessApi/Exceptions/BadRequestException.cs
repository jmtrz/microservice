using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApi.Exceptions;

public class BadRequestException : Exception
{
    public const HttpStatusCode HTTPCODE = HttpStatusCode.BadRequest;
    
    public static string ProblemResultDetails(Exception ex)
    {        
        ProblemDetails problem = new()
        {
            Status = (int)HttpStatusCode.InternalServerError,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.2",
            Title = "Bad Request",
            Detail = ex.Message
        };
        return JsonSerializer.Serialize(problem);  
    }
}