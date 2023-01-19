using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task02.Models
{
    internal class Student
    {
        [Required]
        private string firstname { get; set; }
        [Required]
        private string lastname { get; set; }
        [Required]
        private string studentNumber { get; set; }
        [Required]
        private string birthdate { get; set; }
        [Required]
        private string email { get; set; }
        [Required]
        private string mothersName { get; set; }
        [Required]
        private string fathersName { get; set; }       

        

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


    }
}
