using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("class")] //Changed the route to this controller
    public class CISClassController : ControllerBase
    {
        private Dictionary<String, CISClass> CISClasses = new Dictionary<String, CISClass>();

        public CISClassController() {
            CISClasses.Add("162-1", 
                new CISClass
                {
                    ClassCode = 162,
                    Section = 1,
                    Instructor = "Professor Bob",
                    Prereqs = new int[] {}
                });
            CISClasses.Add("162-2", 
                new CISClass
                {
                    ClassCode = 162,
                    Section = 2,
                    Instructor = "Professor Rob",
                    Prereqs = new int[] {}
                });
            CISClasses.Add("163-1", 
                new CISClass
                {
                    ClassCode = 163,
                    Section = 1,
                    Instructor = "Professor Joe",
                    Prereqs = new int[] {162}
                });
        }

        [HttpGet("all")]
        public CISClass[] GetAll()
        {
            return this.CISClasses.Values.ToArray();
        }

        [HttpGet("id")]
        public CISClass GetClass(string ClassID)
        {
            return this.CISClasses[ClassID];
        }

        [HttpPost("id")]
        public CISClass[] AddClass([FromBody] CISClass classModel)
        {
            String classId = classModel.ClassCode + "-" + classModel.Section;
            this.CISClasses.Add(classId, classModel);
            return this.GetAll();
        }
    }
}
/*
        [HttpPost]
        public ActionResult Post([FromBody] CISClassClass class)
        {
            String classId = class.ClassCode + "-" + class.Section;
            CISClasses.Add(classId, class);
            return Ok();
        }
*/
