using API.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class FactoryUtils
    {
        public static ResponseModel createResponseModel()
        {
            return new ResponseModel();
        }
    }
}
