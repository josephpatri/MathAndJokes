using Application.Wrappers;
using System.Net;
using System.Text.Json;

namespace WebApi.Middlewares;

public class ErrorHandler
{
    private readonly RequestDelegate next;

    public ErrorHandler(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await this.next(context);
        }
        catch (Exception ex)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var responseModel = new Response<string>()
            { Succeded = false, Message = ex.Message };
            switch (ex)
            {
                case Application.Exceptions.ApiException e:
                    // Custom application error API
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case Application.Exceptions.ValidationException e:
                    // Custom application error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.Errors = e.Errors;
                    break;
                case KeyNotFoundException e:
                    // Not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    // Unhandle error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(responseModel);
            await response.WriteAsync(result);
        }
    }
}
