using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrudOperationProject.Operations.Interface;
using CrudOperationProject.Model;
using CrudOperationProject.Helpers.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace CrudOperationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopCakeController : ControllerBase
    {
        private readonly Ishopcakeops _shopcakeOps;
        private readonly IAPIResponseHelper responseHelper;

        public ShopCakeController(Ishopcakeops shopcakeOps, IAPIResponseHelper responseHelper)
        {
            this._shopcakeOps = shopcakeOps;
            this.responseHelper = responseHelper;
        }

        [HttpGet("")]

        public IActionResult GetCakes()
        {
            var response = _shopcakeOps.GetCakes();
            return responseHelper.CreateResponse(response);


        }

        [HttpGet("{Id}")]

        public IActionResult GetCakesById([FromRoute] int Id)
        {
            if (Id < 1)
            {
                return BadRequest();
            }
            var response = _shopcakeOps.GetCakesById(Id);
            return responseHelper.CreateResponse(response);
        }

        [HttpPost("")]

        public IActionResult SaveCakes([FromBody] ShopCake shopcake)
        {
            if (string.IsNullOrWhiteSpace(shopcake.Name))
            {
                return BadRequest();
            }
            var response = _shopcakeOps.SaveCakes(shopcake);
            return responseHelper.CreateResponse(response);

        }
        [HttpPut("{id}")]

        public IActionResult Updatecakes([FromRoute] int id, [FromBody] ShopCake shopcake)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(shopcake.Name))
            {
                return BadRequest();
            }
            shopcake.Id = id;
            var response = _shopcakeOps.Updatecakes(shopcake);
            return responseHelper.CreateResponse(response);

        }
      /*  [HttpGet("export")]
        public IActionResult Exportcakes([FromQuery]int id ,string name)
        {

            var result = _shopcakeOps.Exportcakes(id,name);
            var filename = "shop" + "_" + DateTime.UtcNow.ToString() + ".csv";
            return result == null ? responseHelper.CreateResponse(result) : responseHelper.GetFile(result, filename, "text/csv");
        }*/
    }
}