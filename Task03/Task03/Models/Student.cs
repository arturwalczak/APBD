using System;
using System.Collections;
using System.Collections.Generic;

namespace Task03.Models
{
    public class Student
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string indexNumber { get; set; }
        public string birthdate { get; set; }
        public string studies { get; set; }
        public string mode { get; set; }
        public string email { get; set; }
        public string mothersName { get; set; }
        public string fathersName { get; set; }

        public static List<Student> students = new List<Student>();

        

        public Student(string firstName, string lastName, string indexNumber, string birthdate, string studies, string mode, string email, string mothersName, string fathersName)
        {
            this.firstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            this.lastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            this.indexNumber = indexNumber ?? throw new ArgumentNullException(nameof(indexNumber));
            this.birthdate = birthdate ?? throw new ArgumentNullException(nameof(birthdate));
            this.studies = studies ?? throw new ArgumentNullException(nameof(studies));
            this.mode = mode ?? throw new ArgumentNullException(nameof(mode));
            this.email = email ?? throw new ArgumentNullException(nameof(email));
            this.mothersName = mothersName ?? throw new ArgumentNullException(nameof(mothersName));
            this.fathersName = fathersName ?? throw new ArgumentNullException(nameof(fathersName));
            
        }

        public static void AddStudent(Student student)
        {
            students.Add(student);
        }


    }
}
