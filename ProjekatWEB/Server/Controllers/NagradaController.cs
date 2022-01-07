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

        [Route("PreuzmiNagrade/{idIgre}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiNagrade(int idIgre)
        {
            if(idIgre <= 0)
            {
                return BadRequest("Nepostojeca igra!");
            }
            
            try
            {
                var igra = Context.Igre.Where(p => p.ID == idIgre).FirstOrDefault();
                var nagrade = await Context.Nagrade.Where(p => p.IgraFK == igra).ToListAsync();
                return Ok(nagrade);
                //return Ok(await Context.Nagrade.Select(p => new { p.ID, p.NazivOrg, p.Kategorija }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            } 
        }
        
    }
}
