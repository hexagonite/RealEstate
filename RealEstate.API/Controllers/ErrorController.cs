using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.Controllers
{
    [AllowAnonymous]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BasicController
    {
        [HttpGet]
        public IActionResult Error()
        {
            throw new Exception("Test error message");
        }
    }
}
