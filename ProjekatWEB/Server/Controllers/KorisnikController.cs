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
    public class KorisnikController : ControllerBase
    {
        public SajtContext Context { get; set; }

        public KorisnikController(SajtContext context)
        {
            Context = context;
        }

        [Route("PreuzmiKorisnika")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiKorisnika()
        {
            try
            {
                return Ok(await Context.Korisnici.Select(p => new { p.ID, p.Username }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            } 
        }

        [Route("DodatiPredmet")]
        [HttpPost]
        public async Task<ActionResult> DodatiPredmet([FromBody] Korisnik korisnik)
        {
            if (string.IsNullOrWhiteSpace(korisnik.Username) || korisnik.Username.Length > 50)
            {
                return BadRequest("Neodgovarajuce korisnicko ime!");
            }

            try
            {
                Context.Korisnici.Add(korisnik);
                await Context.SaveChangesAsync();
                return Ok($"Korisnik je dodat! ID je: {korisnik.ID}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}