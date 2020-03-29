using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {

        private IDbService _dbService; 

       public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult getStudents(string orderBy="firstName")
        {
            return Ok(_dbService.GetStudents());
        }
        
        [HttpGet("{id}")]
        public IActionResult getStudent(int id) 
        {
            if (id == 1)
            {
                return Ok ("Katarzyna");
            }
            else if (id == 2)
            {
                return Ok ("Jan");
            }
            return NotFound("Student was not found");
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            //student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult getUpdate(int id)
        {
            return Ok("Update complete");
        }

        [HttpDelete("{id}")]
        public IActionResult getDelete(int id)
        {
            return Ok("Delete complete");
        }
    }
}



//int age = 10;
//var s1 = "Ala is " + age + " years old";
//var s2 = string.Format("Ala is {0} years old", age);
//var s3 = $"Ala is {age} years old";