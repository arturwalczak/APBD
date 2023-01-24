using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;
using Task03.Models;

namespace Task03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {


        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(JsonSerializer.Serialize(Student.students));
        }

        [HttpGet("indexNumber")]
        public IActionResult GetStudent(string indexNumber)
        {
            Student studentFound = Student.students.Find(Student => Student.indexNumber.Equals(indexNumber));
            if(studentFound == null)
            {
                return BadRequest("Student with indexNumber: " + indexNumber + " not found");
            }
            else
            {
                return Ok(studentFound);
            }
        }

        [HttpPut("indexNumber")]
        public IActionResult UpdateStudent(string indexNumber, Student student)
        {
            Student studentFound = Student.students.Find(Student => Student.indexNumber.Equals(indexNumber));
            if(studentFound == null && indexNumber != student.indexNumber)
            {
                return BadRequest("Student with indexNumber: " + indexNumber + " not found");
            }
            Student.students.Remove(studentFound);
            try
            {                
                Student.students.Add(student);
            }
            catch
            {
                return BadRequest("Student cannot be edited");
            }
            Program.SaveStudents();
            return Ok(student);     


        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (!Regex.IsMatch(student.indexNumber, @"s[0-9]+")) 
            { 
                return BadRequest("indexNumber has invalid format"); 
            }
            Student s1;
            bool found = false;
            foreach(Student s in Student.students)
            {
                if (s.indexNumber.Equals(student.indexNumber))
                {
                    found = true;
                }
            }
            
            if(found)
            {
                return BadRequest("Student with this indexNumber already exists");
            }
            try
            {
                Student.AddStudent(student);
                Program.SaveStudents();
                return Ok("Student added");
            }
            catch
            {
                return BadRequest("Student can't be created, invalid data");
            }
            

        }

        [HttpDelete("indexNumber")]
        public IActionResult DeleteStudent(string indexNumber)
        {
            Student.students.Remove(Student.students.Find(Student => Student.indexNumber.Equals(indexNumber)));
            Program.SaveStudents();
            return Ok("Student deleted");
            
        }


    }
}
