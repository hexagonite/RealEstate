using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.Controllers
{
    [Produces("text/plain")]
    public class HealthCheckController : BasicController
    {
        [HttpGet]
        public string Get()
        {
            return "Healthy";
        }
    }
}
