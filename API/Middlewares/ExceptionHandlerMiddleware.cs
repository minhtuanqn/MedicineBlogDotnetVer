using API.Model;
using Business.Exceptions;
using Data.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                
                HttpResponse response = context.Response;
                response.ContentType = "application/json";
                ResponseModel responseModel = FactoryUtils.createResponseModel();
                Dictionary<string, string> errorMap = new Dictionary<string, string>();
                switch (error)
                {
                    case SQLException e:
                        errorMap.Add("System error", e.message);
                        responseModel.statusCode = 500;
                        break;
                    case BusinessException e:
                        errorMap.Add("Bad request", e.message);
                        responseModel.statusCode = 400;
                        break;
                    default:
                        errorMap.Add("System error", "Oops! We will fix as soon as posible");
                        responseModel.statusCode = 500;
                        break;
                }
                responseModel.data = errorMap;
                responseModel.message = "Some errors occur";
                string result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
