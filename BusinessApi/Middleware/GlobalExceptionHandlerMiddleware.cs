using System.Net;
using System.Text.Json;
using BusinessApi.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApi.Middlware;

public class GlobalExceptionHandlerMiddlware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (System.Exception ex)
        {                      
            await HandleExceptionAsync(context, ex);
        }
    }

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
            CustomkeyNotFoundException
            => (
                CustomkeyNotFoundException.HTTPCODE,
                CustomkeyNotFoundException.ProblemResultDetails(ex)
            ),
            _ => (
                BadRequestException.HTTPCODE,
                BadRequestException.ProblemResultDetails(ex)
            )
        };
}