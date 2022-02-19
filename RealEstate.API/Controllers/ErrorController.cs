using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RealEstate.API.Controllers
{
    [AllowAnonymous]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BasicController
    {
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Error()
        {
            throw new Exception("Test error message");
        }
    }
}
