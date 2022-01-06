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
        public async Task<ActionResult> PreuzmiKolicinuProdatih(int idIgre)
        {
            if(idIgre <= 0)
            {
                return BadRequest("Nepostojeca igra!");
            }

            try
            {
                int ukupnaKolicina = 0;
                var igra = Context.Igre.Where(p => p.ID == idIgre).FirstOrDefault();
                var prodavnica = await Context.Prodavnice.Where(p => p.IgraFK == igra).ToListAsync();
                foreach (var p in prodavnica)
                {
                    ukupnaKolicina += p.KolicinaProdatih;
                }
                
                return Ok(ukupnaKolicina);
                //return Ok(await Context.Prodavnice.Select(p => new { p.ID, p.KolicinaProdatih }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            } 
        }

        [Route("PromeniKolicinuProdatihBody")]
        [HttpPut]
        public async Task<ActionResult> PromeniKolicinuProdatih([FromBody] Prodavnica prodavnica)
        {
            if (prodavnica.ID <= 0)
            {
                return BadRequest("Pogrešan ID!");
            }

            if (prodavnica.IDProdavnice < 1 && prodavnica.IDProdavnice > 2)
            {
                return BadRequest("Ne postoji prodavnica sa ovim ID-em!");
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
                return Ok($"Uspešno izmenjena kolicina prodatih kopija u prodavnici sa ID-em: {prodavnica.IDProdavnice}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PromeniKolicinuProdatih/{id}/{idP}/{korpa}")]
        [HttpPut]
        public async Task<ActionResult> Promeni(int id, int idP, int korpa)
        {
            if (id <= 0)
            {
                return BadRequest("Pogrešan ID!");
            }
            if (idP <=0)
            {
                return BadRequest("Nepostojeca prodavnica!");
            }
            if (korpa <= 0)
            {
                return BadRequest("Korpa je prazna!");
            }

            try
            {
                var prodavnica = Context.Prodavnice.Where(p => p.ID == id && p.IDProdavnice == idP).FirstOrDefault();

                if (prodavnica != null)
                {
                    prodavnica.KolicinaProdatih += korpa;

                    await Context.SaveChangesAsync();
                    return Ok($"Uspešno izmenjena kolicina prodatih kopija u prodavnici sa ID-em: {prodavnica.IDProdavnice}");
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
