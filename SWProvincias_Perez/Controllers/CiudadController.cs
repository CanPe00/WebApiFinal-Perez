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
    public class CiudadController : ControllerBase
    {
        private DBPaisFinalContext context;

        public CiudadController(DBPaisFinalContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ciudad>> Get()
        {
            return context.ciudades.Include(p=>p.Provincia).ToList();
        }

        [HttpPost]
        public ActionResult Post(Ciudad ciudad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.ciudades.Add(ciudad);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Ciudad ciudad)
        {
            if (id != ciudad.IdCiudad)
            {
                return BadRequest();
            }
            context.Entry(ciudad).State = EntityState.Modified;
            context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Ciudad> Delete(int id)
        {
            Ciudad ciudad = (from c in context.ciudades
                                   where c.IdCiudad == id
                                   select c).SingleOrDefault();

            if (ciudad == null)
            {
                return NotFound();
            }
            context.ciudades.Remove(ciudad);
            context.SaveChanges();
            return ciudad;
        }
    }
}
