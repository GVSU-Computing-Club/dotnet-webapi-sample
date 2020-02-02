using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyAPI.Models;

using Microsoft.EntityFrameworkCore;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("class")] //Changed the route to this controller to /class/
    public class CISClassController : ControllerBase
    {
        // private Dictionary<String, CISClassModel> CISClasses = new Dictionary<String, CISClassModel>();

        // public CISClassController() {
        //     CISClasses.Add("162-1", 
        //         new CISClassModel
        //         {
        //             ClassCode = 162,
        //             Section = 1,
        //             Instructor = "Professor Bob"
        //         });
        //     CISClasses.Add("162-2", 
        //         new CISClassModel
        //         {
        //             ClassCode = 162,
        //             Section = 2,
        //             Instructor = "Professor Rob"
        //         });
        //     CISClasses.Add("163-1", 
        //         new CISClassModel
        //         {
        //             ClassCode = 163,
        //             Section = 1,
        //             Instructor = "Professor Joe"
        //         });
        // }

        private readonly CISClassContext _context;

        public CISClassController(CISClassContext context) => _context = context;

        //GET /class/all Request to get all of our data
        [HttpGet("all")]
        public List<CISClassModel> GetAll()
        {
            return _context.CISClassItems.ToList();
        }

        //GET /class/id Request to get info on a class based on the class id (Format: Code-section)
        [HttpGet("id")]
        public ActionResult<CISClassModel> GetClass(int id)
        {
            var result = _context.CISClassItems.Find(id);
            if (result == null) {
                return NotFound("Class with ID not found");
            }
            return result;
        }

        //POST /class/id Adds a new class to the dictionary
        [HttpPost("id")]
        public ActionResult<CISClassModel> AddClass([FromBody] CISClassModel newClass)
        {
            _context.CISClassItems.Add(newClass);
            _context.SaveChanges();

            return CreatedAtAction("GetClass", new CISClassModel{ID = newClass.ID}, newClass);
        }

        //PUT class/
        [HttpPut("{id}")]
        public ActionResult UpdateClass(int id, [FromBody] CISClassModel myClass) {
            if (id != myClass.ID) {
                return BadRequest();
            }

            _context.Entry(myClass).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        //DELETE class/{id}
        [HttpDelete("id")]
        public ActionResult<CISClassModel> DeleteClass(int id) {
            var result = _context.CISClassItems.Find(id);
            if (result == null) {
                return NotFound();
            }

            _context.CISClassItems.Remove(result);
            _context.SaveChanges();

            return result;
        }
    }
}
