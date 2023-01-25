using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWProvincias_Perez.Data;
using SWProvincias_Perez.Models;
using System.Collections.Generic;
using System.Linq;

namespace SWProvincias_Perez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        private DBPaisFinalContext context;

        public ProvinciaController(DBPaisFinalContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Provincia>> Get() 
        {
            return context.provinicias.ToList();
        }

        [HttpPost]
        public ActionResult Post(Provincia provincia) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.provinicias.Add(provincia);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id,[FromBody]Provincia provincia) 
        {
            if (id != provincia.IdProvincia)
            {
                return BadRequest();
            }
            context.Entry(provincia).State= EntityState.Modified;
            context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Provincia> Delete(int id) 
        { 
            Provincia provincia = (from p in context.provinicias
                                   where p.IdProvincia == id
                                   select p).SingleOrDefault();

            if (provincia == null)
            {
                return NotFound();
            }
            context.provinicias.Remove(provincia);
            context.SaveChanges();
            return provincia;
        }
    }
}
