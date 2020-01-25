using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyAPI.Models;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("class")] //Changed the route to this controller to /class/
    public class CISClassController : ControllerBase
    {
        private Dictionary<String, CISClassModel> CISClasses = new Dictionary<String, CISClassModel>();

        public CISClassController() {
            CISClasses.Add("162-1", 
                new CISClassModel
                {
                    ClassCode = 162,
                    Section = 1,
                    Instructor = "Professor Bob"
                });
            CISClasses.Add("162-2", 
                new CISClassModel
                {
                    ClassCode = 162,
                    Section = 2,
                    Instructor = "Professor Rob"
                });
            CISClasses.Add("163-1", 
                new CISClassModel
                {
                    ClassCode = 163,
                    Section = 1,
                    Instructor = "Professor Joe"
                });
        }

        //GET /class/all Request to get all of our data
        [HttpGet("all")]
        public CISClassModel[] GetAll()
        {
            return this.CISClasses.Values.ToArray();
        }

        //GET /class/id Request to get info on a class based on the class id (Format: Code-section)
        [HttpGet("id")]
        public CISClassModel GetClass(string ClassID)
        {
            return this.CISClasses[ClassID];
        }

        //POST /class/id Adds a new class to the dictionary
        [HttpPost("id")]
        public CISClassModel[] AddClass([FromBody] CISClassModel classModel)
        {
            String classId = classModel.ClassCode + "-" + classModel.Section;
            this.CISClasses.Add(classId, classModel);
            return this.GetAll();
        }
    }
}
