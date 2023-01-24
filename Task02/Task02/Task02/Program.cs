using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task02.Models;
using Task02.Exceptions;
using Formatting = Newtonsoft.Json.Formatting;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using FileNotFoundException = Task02.Exceptions.FileNotFoundException;

namespace Task02
{
    internal class Program
    {

        private static bool allValluesNotNullorEmpty(string[] strings)
        {
            bool allValluesNotNullorEmpty = true;
            foreach(string s in strings)
            {
                if (string.IsNullOrEmpty(s))
                {
                    allValluesNotNullorEmpty = false;
                }
            }
            return allValluesNotNullorEmpty;
        }
        static void Main(string[] args)
        {
            List<string> log = new List<string>();

            string data = args[0];
            string output = args[1];
            string extension = args[2];

            if (!File.Exists(data))
            {
                log.Add("FileNotFoundException(\"File not found\")");
                throw new FileNotFoundException("File not found");                
            }

            if (String.IsNullOrEmpty(data) && String.IsNullOrEmpty(output) && String.IsNullOrEmpty(extension))
            {
                throw new ArgumentException("No arguments provided");
            }

            List<string> dataList = new List<string>();
            var fileInfo = new FileInfo(data);
            
            University university = new University(DateTime.Now.ToString("dd/MM/yyyy"), "Jan Kowalski");


            using (var streamReader = new StreamReader(fileInfo.OpenRead()))
            {
                string line = null;
                while ((line = streamReader.ReadLine()) != null)
                {
                    dataList.Add(line);
                }
            }

            

            foreach (var line in dataList)
            {
                string[] items = line.Split(",");               
                
                if (items.Length == 9 && !Student.isStudent(items[0], items[1], items[4]) && allValluesNotNullorEmpty(items))
                {
                    Student student = new Student(items[0], items[1], items[4], items[5], items[6], items[7], items[8]);
                    
                    activeStudies.addStudies(items[2], items[3]);                    
                }
                else
                {
                    log.Add("Cant add student " + items[0] + " " + items[1] + " " + items[4]);
                }
            }
            university.students = Student.students;            

            university.activeStudies = activeStudies.studies.Distinct().ToList(); 
            

            if(extension == "json")
            {               

                using (var writer = new StreamWriter(output+"output.json"))
                {
                    var json = JsonConvert.SerializeObject(university, Formatting.Indented);                 
                    writer.Write(json);
                }
            }

            using (var writer = new StreamWriter("log.txt"))
            {                
                foreach (var logs in log)
                {
                    writer.WriteLine(logs);
                }
            }

        }
    }
}
