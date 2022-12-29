using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.Models
{
    internal class University
    {
        [JsonProperty]
        private string createdAt { get; set; }
        [JsonProperty]
        private string author { get; set; }
        [JsonProperty]
        public List<Student> students { get; set; }
        public List<activeStudies> activeStudies { get; set; }

        public University(string createdAt, string author)
        {
            this.createdAt = createdAt;
            this.author = author;
        }

        
    }
}
