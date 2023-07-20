using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleTask.Models
{
    public class Teacher : BaseEntity
    {

        private static int counter = 0;

        public Teacher(string name, string surname, double salary, DateOnly birthDay)
        {
            Name = name;
            Surname = surname; 
            Salary = salary;
            Birthday = birthDay;

            Id = counter;
            counter++;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public double Grade { get; set; }
        public double Salary { get; set; }
        public DateOnly Birthday { get; set; }
    }
}
