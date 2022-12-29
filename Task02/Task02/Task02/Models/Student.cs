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
        [JsonProperty]
        private string firstname { get; set; }
        [JsonProperty]
        private string lastname { get; set; }
        [JsonProperty]
        private string studentNumber { get; set; }
        [JsonProperty]
        private string birthdate { get; set; }
        [JsonProperty]
        private string email { get; set; }
        [JsonProperty]
        private string mothersName { get; set; }
        [JsonProperty]
        private string fathersName { get; set; }
        

        private List<activeStudies> studies = new();

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

        public void addStudies (activeStudies studies)
        {
            this.studies.Add (studies);
        }

        public static bool isStudent(string firstname, string lastname, string studentNumber)
        {
            if (students.Find(c => (c.firstname == firstname) && (c.lastname == lastname) && (c.studentNumber == studentNumber)) != null)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "firstname " + firstname + " lastname " + lastname + " student number " + studentNumber;
        }


    }
}
