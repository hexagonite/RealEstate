using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Error()
        {
            throw new Exception("Test message");
        }
    }
}
