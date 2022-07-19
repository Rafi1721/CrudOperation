using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Collections.Generic;

namespace CrudOperationProject.Helpers.Interface
{
    public interface IAPIResponseHelper
    {
        public IActionResult CreateResponse(dynamic result);
        public IActionResult GetFile(byte[] data, string fileName, string media);
        IActionResult GetFile(object result, string filename, string v);
    }
}

