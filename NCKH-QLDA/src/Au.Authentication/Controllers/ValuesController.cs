using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Au.Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Content(@"<html><body style='background-color:powderblue;'>
                     <h1 style = 'color:red;'>Hello World!</h1>
                     <h2 style = 'color:green;'> Welcome to HUMG.</h2>
                      </body></html>", "text/html");
        }

    }
}
