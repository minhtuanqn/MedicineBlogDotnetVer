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

        public ResponseModel Status(int statusCode)
        {
            _statusCode = statusCode;
            return this;
        }

        public ResponseModel Data(object data)
        {
            _data = data;
            return this;
        }

        public ResponseModel  Message(string message)
        {
            _message = message;
            return this;
        }

        public JsonResult convertToJson()
        {
            return new JsonResult(this);
        }

        public int _statusCode { get; set; }

        public object _data { get; set; }

        public string _message { get; set; }

    }
}
