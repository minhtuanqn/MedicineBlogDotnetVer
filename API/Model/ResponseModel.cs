using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public class ResponseModel
    {
        public ResponseModel() { }

        public ResponseModel StatusCode(int status)
        {
            statusCode = status;
            return this;
        }

        public ResponseModel Data(object responseData)
        {
            data = responseData;
            return this;
        }

        public ResponseModel Message(string responseMessage)
        {
            message = responseMessage;
            return this;
        }

        public JsonResult convertToJson()
        {
            return new JsonResult(this);
        }

        public int statusCode { get; set; }

        public object data { get; set; }

        public string message { get; set; }

    }
}
