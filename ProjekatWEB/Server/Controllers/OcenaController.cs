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
    public class OcenaController : ControllerBase
    {
        public SajtContext Context { get; set; }

        public OcenaController(SajtContext context)
        {
            Context = context;
        }

        [Route("DodajOcenu/{gameplay}/{story}/{music}/{graphics}/{idIgre}/{username}")]
        [HttpPost]
        public async Task<ActionResult> DodajOcenu(int gameplay,int story, int music, int graphics, int idIgre, string username)
        {
            if (gameplay < 1 || gameplay > 5)
            {
                return BadRequest("Unesite broj izmedju 1 i 5!");
            }
            if (story < 1 || story > 5)
            {
                return BadRequest("Unesite broj izmedju 1 i 5!");
            }
            if (music < 1 || music > 5)
            {
                return BadRequest("Unesite broj izmedju 1 i 5!");
            }
            if (graphics < 1 || graphics > 5)
            {
                return BadRequest("Unesite broj izmedju 1 i 5!");
            }
            if (idIgre <= 0)
            {
                return BadRequest("Niste uneli igru!");
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                return BadRequest("Niste uneli odgovarajuce korisnicko ime!");
            }

            var igra = Context.Igre.Where(p => p.ID == idIgre).FirstOrDefault();
            var korisnik = Context.Korisnici.Where(p => p.Username == username).FirstOrDefault();
            if(korisnik == null)
            {
                return Forbid("Dati korisnik ne postoji.Morate se registrovati!");
            }
            var ocenaPostoji = Context.Ocene.Where(p => p.IgraFK == igra && p.KorisnikFK == korisnik).FirstOrDefault();
            if(ocenaPostoji != null)
            {
                return BadRequest("Korisnik je vec uneo ocenu za odabranu igru!");
            }
            try
            {
                Ocena o = new Ocena
                {
                    Gameplay = gameplay,
                    Story = story,
                    Music = music,
                    Graphics = graphics,
                    IgraFK = igra,
                    KorisnikFK = korisnik
                };
                Context.Ocene.Add(o);
                await Context.SaveChangesAsync();

                var ocene = await Context.Ocene.Where(p => p.IgraFK == igra).ToListAsync();
                double ocena = 0;
                foreach (var p in ocene)
                {
                    double pom = 0;
                    pom += p.Gameplay;
                    pom += p.Graphics;
                    pom += p.Music;
                    pom += p.Story;
                    ocena += pom / 4;
                }

                double prosek = ocena / ocene.Count;
                double prosecnaOcena = Math.Round(prosek,2,MidpointRounding.ToEven);
                var pomObj = new {igra.ID,igra.Naziv,igra.Zanr,igra.GodinaIzlaska,igra.Developer,igra.Publisher,prosecnaOcena};

                return Ok(pomObj);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("ObrisiOcenu/{idIgre}/{username}")]
        [HttpDelete]
        public async Task<ActionResult> ObrisiOcenu(int idIgre, string username)
        {
            if (idIgre <= 0)
            {
                return BadRequest("Nepostojeca igra!");
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                return BadRequest("Niste uneli odgovarajuce korisnicko ime!");
            }

            var igra = Context.Igre.Where(p => p.ID == idIgre).FirstOrDefault();
            var korisnik = Context.Korisnici.Where(p => p.Username == username).FirstOrDefault();

            if(korisnik == null)
            {
                return BadRequest("Dati korisnik ne postoji.Morate se registrovati!");
            }

            try
            {
                var ocena = await Context.Ocene.Where(p => p.IgraFK == igra && p.KorisnikFK == korisnik).FirstOrDefaultAsync();
                if(ocena == null)
                {
                    return BadRequest("Korisnik nije dao ocenu odabranoj igri!");
                }
                Context.Ocene.Remove(ocena);
                await Context.SaveChangesAsync();
                return Ok("Uspešno izbrisana ocena");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
