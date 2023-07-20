using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTask.Models;
using System.Threading.Tasks;

namespace ConsoleTask.Services
{
    public class ClassroomService
    {
        private List<Student> students;
        private List<Teacher> teachers;

        public ClassroomService()
        {
            students = new();
            teachers = new();
        }
        public List<Teacher> GetTeacher()
        {
            return teachers;
        }
        

        public List<Student> GetStudents()
        {
            return students;
        }

        public void AddStudent(string name, string surname, double grade, DateTime birthDay)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name can't be empty!");

            if (string.IsNullOrWhiteSpace(surname)) throw new Exception("Surname can't be empty!");

            if (grade < 0) throw new ArgumentOutOfRangeException("Grade can't be negative!");

            var student = new Student(name, surname, grade, birthDay);

            students.Add(student);
        }
        public void AddTeacher(string name, string surname,double salary,DateOnly birthday)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name can not be empty!");
            if (string.IsNullOrWhiteSpace(surname)) throw new Exception("Surname can not be empty!");
            if (salary < 0) throw new Exception("Amount of salary can't be less than 0!");


            Teacher? teacher = new Teacher(name, surname, salary, birthday);
            teachers.Add(teacher);
            

        }

        public void RemoveStudent(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException("Id can't be negative!");

            var existingStudent = students.FirstOrDefault(x => x.Id == id);

            if (existingStudent == null) throw new Exception("Not found!");

            students = students.Where(x => x.Id != id).ToList();
        }
        public void RemoveTeacher(int id)
        {
            if(id < 0) throw new Exception("Id can't be less than 0!");
            var existingTeacher = teachers.FirstOrDefault(x => x.Id == id);
            if (existingTeacher == null) throw new Exception("Not Found!");

            teachers = teachers.Where(x=>x.Id != id).ToList();

        }

        public List<Student> FindStudentsByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name can't be empty!");

            var foundStudents = students.Where(x => x.Name.ToLower().Trim() == name.ToLower().Trim()).ToList();

            return foundStudents;
        }
        public List<Teacher> FindTeacherByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name can't be empty!");
            var foundTeacher = teachers.Where(x => x.Name.ToLower().Trim() == name).ToList();
            return foundTeacher;
        }


        public void UpdateStudent(int id, string name, string surname, double grade, DateTime birthDay)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name can't be empty!");

            if (string.IsNullOrWhiteSpace(surname)) throw new Exception("Surname can't be empty!");

            if (grade < 0) throw new ArgumentOutOfRangeException("Grade can't be negative!");

            var existingStudent = students.FirstOrDefault(x => x.Id == id);

            if (existingStudent == null) throw new Exception("Student not found!");

            existingStudent.Name = name;
            existingStudent.Surname = surname;
            existingStudent.Grade = grade;
            existingStudent.Birthday = birthDay;
        }

        public void UpdateTeacher(int id,string name,string surname,double salary, DateOnly birthday)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name can't be empty!");
            if (string.IsNullOrWhiteSpace(surname)) throw new Exception("Surname can't be empty");
            if (salary < 0) throw new Exception("Salary can't be less than 0!");

            var existingTeacher = teachers.FirstOrDefault(x => x.Id == id);
            if (existingTeacher == null) throw new Exception("Not Found!");

            existingTeacher.Name = name;
            existingTeacher.Surname= surname;
            existingTeacher.Salary = salary;
            existingTeacher.Birthday = birthday;

        }

        public List<Student> SearchStudentsByBday(DateTime minDate, DateTime maxDate)
        {
            if (minDate > maxDate) throw new Exception("Min date can't be more than Max date!");

            return students.Where(x => x.Birthday >= minDate && x.Birthday <= maxDate).ToList();
        }

        public List<Teacher> SearchTeachersByBday(DateOnly minDate,DateOnly maxDate)
        {
            if (minDate > maxDate) throw new Exception("MinDate can't be more than maxDate");
            return teachers.Where(x => x.Birthday >= minDate && x.Birthday <= maxDate).ToList();

        }
    }
}
