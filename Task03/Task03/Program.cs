using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Task03.Models;

namespace Task03
{
    public class Program
    {
        private static void GetStudents()
        {
            string data = "Data.csv";
            var fileInfo = new FileInfo(data);
            List<string> dataList = new List<string>();

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
                try
                {
                    string[] items = line.Split(",");
                    Student student1 = new Student(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7], items[8]);
                    Student.AddStudent(student1);
                }
                catch
                {
                    Console.WriteLine("Student not created");
                }
            }
        }

        public static void SaveStudents()
        {
            using (StreamWriter writer = new StreamWriter("Data.csv"))
            {
                foreach (Student student in Student.students)
                {
                    writer.WriteLine($"{student.firstName},{student.lastName},{student.indexNumber},{student.birthdate},{student.studies},{student.mode},{student.email},{student.mothersName},{student.fathersName} ");
                }
            }
        }

        public static void Main(string[] args)
        {
            GetStudents();
            CreateHostBuilder(args).Build().Run();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
