using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.Models
{
    internal class activeStudies
    {
        [JsonProperty]
        private string name { get; set; }
        [JsonProperty]
        private string mode { get; set; }
        [JsonProperty]
        private int numberOfStudents { get; set; }          

        public static List<activeStudies> studies = new();

        public activeStudies(string name, string mode)
        {
            this.name = name;
            this.mode = mode;
            studies.Add(this);
            numberOfStudents = 1;
        }

        public void addStudent()
        {
            numberOfStudents++;
        }

        public static void addStudies (String name, string mode)
        {      
            
            if(studies.Find(c => (c.name == name) && (c.mode == mode)) != null)
            {
                studies.Find(c => (c.name == name) && (c.mode == mode)).addStudent();
            }
            else
            {
                studies.Add(new activeStudies(name, mode));
            }
        }
    }
}
