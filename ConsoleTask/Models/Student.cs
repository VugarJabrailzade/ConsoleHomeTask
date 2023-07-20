﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTask.Models
{
    public class Student : BaseEntity
    {
        private static int counter = 0;

        public Student(string name, string surname, double grade, DateTime birthDay)
        {
            Name = name;
            Surname = surname;
            Grade = grade;
            Birthday = birthDay;

            Id = counter;
            counter++;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public double Grade { get; set; }
        public DateTime Birthday { get; set; }
    }
}
