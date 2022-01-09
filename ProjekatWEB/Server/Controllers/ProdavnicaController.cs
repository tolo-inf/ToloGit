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
    public class ProdavnicaController : ControllerBase
    {
        public SajtContext Context { get; set; }

        public ProdavnicaController(SajtContext context)
        {
            Context = context;
        }

        [Route("PreuzmiKolicinuProdatih/{idIgre}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiKolicinuProdatih(int idIgre) // ne treba mi
        {
            if(idIgre <= 0)
            {
                return BadRequest("Nepostojeca igra!");
            }

            try
            {
                var igra = Context.Igre.Where(p => p.ID == idIgre).FirstOrDefault();
                var prodavnica = await Context.Prodavnice.Where(p => p.IgraFK == igra).FirstOrDefaultAsync();
                return Ok(prodavnica.KolicinaProdatih);
                //return Ok(await Context.Prodavnice.Select(p => new { p.ID, p.KolicinaProdatih }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            } 
        }

        [Route("PreuzmiArtikl/{idIgre}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiArtikl(int idIgre)
        {
            if(idIgre <= 0)
            {
                return BadRequest("Nepostojeca igra!");
            }

            try
            {
                var igra = Context.Igre.Where(p => p.ID == idIgre).FirstOrDefault();
                var prodavnica = await Context.Prodavnice.Where(p => p.IgraFK == igra).FirstOrDefaultAsync();
                return Ok(prodavnica);
                //return Ok(await Context.Prodavnice.Select(p => new { p.ID, p.KolicinaProdatih }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            } 
        }

        [Route("PromeniKolicinuProdatihBody")]
        [HttpPut]
        public async Task<ActionResult> PromeniKolicinuProdatihBody([FromBody] Prodavnica prodavnica) // ne treba mi
        {
            if (prodavnica.ID <= 0)
            {
                return BadRequest("Pogrešan ID!");
            }

            if (prodavnica.CenaIgre < 0 || prodavnica.CenaIgre > 200)
            {
                return BadRequest("Neodgovarajuca cena!");
            }

            if(prodavnica.KolicinaProdatih < 0 || prodavnica.KolicinaProdatih > 1000000000)
            {
                return BadRequest("Neodgovarajuca kolicina!");
            }

            try
            {
                Context.Prodavnice.Update(prodavnica);

                await Context.SaveChangesAsync();
                return Ok("Uspešno izmenjena kolicina prodatih kopija!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PromeniKolicinuProdatih/{idIgre}/{korpa}")]
        [HttpPut]
        public async Task<ActionResult> PromeniKolicinuProdatih(int idIgre, int korpa)
        {
            if (idIgre <= 0)
            {
                return BadRequest("Pogrešan ID!");
            }
            if (korpa <= 0)
            {
                return BadRequest("Korpa je prazna!");
            }

            try
            {
                var igra = Context.Igre.Where(p => p.ID == idIgre).FirstOrDefault();
                var prodavnica = Context.Prodavnice.Where(p => p.IgraFK == igra).FirstOrDefault();

                if (prodavnica != null)
                {
                    prodavnica.KolicinaProdatih += korpa;

                    await Context.SaveChangesAsync();
                    return Ok("Uspešno izmenjena kolicina prodatih kopija");
                }
                else
                {
                    return BadRequest("Artikl nije pronađen!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
