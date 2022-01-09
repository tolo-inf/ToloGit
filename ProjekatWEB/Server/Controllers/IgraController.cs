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
    public class IgraController : ControllerBase
    {
        public SajtContext Context { get; set; }

        public IgraController(SajtContext context)
        {
            Context = context;
        }

        [Route("PreuzmiIgre")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiIgre()
        {
            try
            {
                return Ok(await Context.Igre.Select(p => new { p.ID, p.Naziv, p.Zanr, p.GodinaIzlaska, p.Developer, p.Publisher }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            } 
        }

        [Route("PreuzmiOdredjenuIgru/{id}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiOdredjenuIgru(int id) // ne treba mi
        {
            if(id <= 0)
            {
                return BadRequest("Nepostojeca igra!");
            }

            try
            {
                return Ok(await Context.Igre.Where(p => p.ID == id).FirstOrDefaultAsync());
                //return Ok(await Context.Igre.Select(p => new { p.ID, p.Naziv, p.Zanr, p.GodinaIzlaska, p.Developer, p.Publisher }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            } 
        }

        [Route("PreuzmiImeIgre/{id}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiImeIgre(int id) // ne treba mi
        {
            if(id <= 0)
            {
                return BadRequest("Nepostojeca igra!");
            }

            try
            {
                var igra = await Context.Igre.Where(p => p.ID == id).FirstOrDefaultAsync();
                return Ok(igra.Naziv);
                //return Ok(await Context.Igre.Select(p => new { p.ID, p.Naziv }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            } 
        }
    }
}
