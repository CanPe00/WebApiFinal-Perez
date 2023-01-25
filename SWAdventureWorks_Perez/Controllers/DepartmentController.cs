using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWAdventureWorks_Perez.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SWAdventureWorks_Perez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private AdventureWorks2019Context context;

        public DepartmentController(AdventureWorks2019Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Department>> Get()
        {
            return context.Departments.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Department> Get(int id)
        {
            Department department = (from d in context.Departments
                                     where d.DepartmentId== id
                                     select d).SingleOrDefault();
            if (department==null)
            {
                return NotFound();
            }
            return department;
        }

        [HttpGet("name/{name}")]
        public ActionResult<Department> Get(string name)
        {
            Department department = (from d in context.Departments
                                     where d.Name== name
                                     select d).SingleOrDefault();
            if (department == null)
            {
                return NotFound();
            }
            return department;
        }

        [HttpPost]
        public ActionResult Post(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Departments.Add(department);
            context.SaveChanges();
            return Ok();
        }



    }
}
