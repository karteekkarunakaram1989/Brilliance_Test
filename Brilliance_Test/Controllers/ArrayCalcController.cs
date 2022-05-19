using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Brilliance_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrayCalcController : ControllerBase
    {
        private readonly IProductService _productService;

        public ArrayCalcController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("reverse")]
        public int[] Reverse([FromQuery] int[] productIds)
        {
            return _productService.ArrayReverse(productIds);
        }

        [HttpGet]
        [Route("deletepart")]
        public ActionResult<int[]> DeletePart([FromQuery] int position, [FromQuery] int[] productIds)
        {
            try
            {
                return _productService.ArrayRemoveAt(productIds, position);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
