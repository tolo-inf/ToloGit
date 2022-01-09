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

        [Route("PreuzmiKorisnika/{id}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiKorisnika(int id) // ne treba mi
        {
            if(id <= 0)
            {
                return BadRequest("Nepostojeci korisnik!");
            }

            try
            {   return Ok(await Context.Korisnici.Where(p => p.ID == id).FirstOrDefaultAsync());
                //return Ok(await Context.Korisnici.Select(p => new { p.ID, p.Username }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            } 
        }

        [Route("DodajKorisnikaBody")]
        [HttpPost]
        public async Task<ActionResult> DodajKorisnikaBody([FromBody] Korisnik korisnik) // ne treba mi
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

        [Route("DodajKorisnika/{username}")]
        [HttpPost]
        public async Task<ActionResult> DodajKorisnika(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return BadRequest("Unesite korisnicko ime!");
            }

            try
            {
                Korisnik k = new Korisnik
                {
                    Username = username
                };

                Context.Korisnici.Add(k);
                await Context.SaveChangesAsync();
                return Ok("Uspešno upisan novi korisnik!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}