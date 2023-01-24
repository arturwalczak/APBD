using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task02.Models
{
    internal class Student
    {
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        public string studentNumber { get; set; }
        [Required]
        public string birthdate { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string mothersName { get; set; }
        [Required]
        public string fathersName { get; set; }       

        

        public static List<Student> students = new();       


        public Student(string firstname, string lastname, string studentNumber, string birthdate, string email, string mothersName, string fathersName)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.studentNumber = studentNumber;
            this.birthdate = birthdate;
            this.email = email;
            this.mothersName = mothersName;
            this.fathersName = fathersName;
            students.Add(this);
        }

        

        public override string ToString()
        {
            return "firstname " + firstname + " lastname " + lastname + " student number " + studentNumber;
        }

        internal static bool isStudent(string v1, string v2, string v3)
        {
            bool studentAlredyExists = false;
            foreach(Student student in students)
            {
                if(student.firstname.Equals(v1) && student.lastname.Equals(v2) && student.studentNumber.Equals(v3))
                {
                    studentAlredyExists = true;
                }                
            }
            return studentAlredyExists;
        }
    }
}
