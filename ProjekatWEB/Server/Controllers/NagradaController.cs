using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NagradaController : ControllerBase
    {
        public SajtContext Context { get; set; }

        public NagradaController(SajtContext context)
        {
            Context = context;
        }

        
    }
}
