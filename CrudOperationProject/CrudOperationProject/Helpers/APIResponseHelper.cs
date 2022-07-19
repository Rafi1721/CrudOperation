using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.IO;
using System.Net.Http.Headers;
using CrudOperationProject.Helpers;
using Ubiety.Dns.Core;
using CrudOperationProject.Helpers.Interface;


namespace CrudOperationProject.Helpers
{
    public class APIResponseHelper : IAPIResponseHelper
    {
        public IActionResult CreateResponse(dynamic result)
        {
            if (result == null)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            if (result is bool)
            {
                return result ? new StatusCodeResult(StatusCodes.Status500InternalServerError) : new OkResult();
            }
            if (result is int)
            {
                if (result == -400)
                    return new StatusCodeResult(StatusCodes.Status400BadRequest);
                else
                    return result < 0 ? new StatusCodeResult(StatusCodes.Status500InternalServerError) : new OkResult();
            }
            return new JsonResult(result);
        }

        public IActionResult GetFile(byte[] fileContent, string fileName, string mediaType)
        {
            var stream = new MemoryStream(fileContent);
            return new FileStreamResult(stream, mediaType)
            {
                FileDownloadName = fileName
            };
        }

        public IActionResult GetFile(object result, string filename, string v)
        {
            throw new NotImplementedException();
        }
    }
}


