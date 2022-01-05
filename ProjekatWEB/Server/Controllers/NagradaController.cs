using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
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

        [Route("PreuzmiNagradu")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiNagradu()
        {
            try
            {
                return Ok(await Context.Nagrade.Select(p => new { p.ID, p.NazivOrg, p.Kategorija }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            } 
        }
        
    }
}
