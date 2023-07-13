using System.Net;
using BusinessApi.Exceptions;
using NotImplementedException = BusinessApi.Exceptions.NotImplementedException;

namespace BusinessApi.Middlware;

public class GlobalExceptionHandlerMiddlware //: IMiddleware
{

    private readonly RequestDelegate _next;
    public GlobalExceptionHandlerMiddlware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (System.Exception ex)
        {                      
            await HandleExceptionAsync(context, ex);
        }
    }

    #region UseThisForStronglyTyped
    // public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    // {
    //     try
    //     {
    //         await next(context);
    //     }
    //     catch (System.Exception ex)
    //     {                      
    //         await HandleExceptionAsync(context, ex);
    //     }
    // }
    #endregion

    protected Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var (code, json) = GenerateResponse(ex);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int) code;
        return context.Response.WriteAsync(json);
    }

    protected (HttpStatusCode code, string json) GenerateResponse(Exception ex)
        => ex switch
        {
            NotFoundException
            => (
                NotFoundException.HTTPCODE,
                NotFoundException.ProblemResultDetails(ex)
            ),
            NotImplementedException
            => (
                NotImplementedException.HTTPCODE,
                NotImplementedException.ProblemResultDetails(ex)
            ),
            _ => (
                BadRequestException.HTTPCODE,
                BadRequestException.ProblemResultDetails(ex)
            )
        };
}