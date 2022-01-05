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

        [Route("PreuzmiProsecnuOcenu/{idIgre}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiProsecnuOcenu(int idIgre)
        {
            if(idIgre <= 0)
            {
                return BadRequest("Nepostojeca igra!");
            }

            try
            {
                var igra = Context.Igre.Where(p => p.ID == idIgre).FirstOrDefault();
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

                double prosecnaOcena = ocena / ocene.Count;
                return Ok(prosecnaOcena);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            } 
        }

        [Route("DodatiOcenu")]
        [HttpPost]
        public async Task<ActionResult> DodatiOcenu([FromBody] Ocena ocena)
        {
            if (ocena.Gameplay < 1 || ocena.Gameplay > 5)
            {
                return BadRequest("Unesite broj izmedju 1 i 5!");
            }
            if (ocena.Story < 1 || ocena.Story > 5)
            {
                return BadRequest("Unesite broj izmedju 1 i 5!");
            }
            if (ocena.Music < 1 || ocena.Music > 5)
            {
                return BadRequest("Unesite broj izmedju 1 i 5!");
            }
            if (ocena.Graphics < 1 || ocena.Graphics > 5)
            {
                return BadRequest("Unesite broj izmedju 1 i 5!");
            }
            if (ocena.IgraFK == null)
            {
                return BadRequest("Niste uneli igru!");
            }
            if (ocena.KorisnikFK == null)
            {
                return BadRequest("Niste uneli odgovarajuce korisnicko ime!");
            }

            try
            {
                Context.Ocene.Add(ocena);
                await Context.SaveChangesAsync();
                return Ok($"Ocena je dodata! ID je: {ocena.ID}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PromeniOcenu")]
        [HttpPut]
        public async Task<ActionResult> PromeniOcenu([FromBody] Ocena ocena)
        {
            if (ocena.ID <= 0)
            {
                return BadRequest("Pogrešan ID!");
            }
            if (ocena.Gameplay < 1 || ocena.Gameplay > 5)
            {
                return BadRequest("Unesite broj izmedju 1 i 5!");
            }
            if (ocena.Story < 1 || ocena.Story > 5)
            {
                return BadRequest("Unesite broj izmedju 1 i 5!");
            }
            if (ocena.Music < 1 || ocena.Music > 5)
            {
                return BadRequest("Unesite broj izmedju 1 i 5!");
            }
            if (ocena.Graphics < 1 || ocena.Graphics > 5)
            {
                return BadRequest("Unesite broj izmedju 1 i 5!");
            }
            if (ocena.IgraFK == null)
            {
                return BadRequest("Niste uneli igru!");
            }
            if (ocena.KorisnikFK == null)
            {
                return BadRequest("Niste uneli odgovarajuce korisnicko ime!");
            }

            try
            {
                Context.Ocene.Update(ocena);

                await Context.SaveChangesAsync();
                return Ok($"Uspešno izmenjena ocena sa ID-em: {ocena.ID}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("IzbrisiOcenu/{id}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisiOcenu(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Pogrešan ID!");
            }

            try
            {
                var ocena = await Context.Ocene.FindAsync(id);
                Context.Ocene.Remove(ocena);
                await Context.SaveChangesAsync();
                return Ok($"Uspešno izbrisana ocena sa ID-em: {id}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
