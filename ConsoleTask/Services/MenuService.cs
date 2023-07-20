using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTask.Models;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTask.Services
{
    public class MenuService
    {
        private static ClassroomService classroomService = new ClassroomService();

        public static void MenuShowStudents()
        {
            var students = classroomService.GetStudents();
           

            if (students.Count == 0)
            {
                Console.WriteLine("No students yet.");
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.Id} | Name: {student.Name} | Surname: {student.Surname} | Grade: {student.Grade} | BDay: {student.Birthday}");
            }
        }
        public static void MenuShowTeacher()
        {
            var teachers =  classroomService.GetTeacher();

            if (teachers.Count == 0)
            {
                Console.WriteLine("No Teacher yet!");
                return;
            }
            foreach (var teach in teachers) 
            {
                Console.WriteLine($"ID: {teach.Id} | Name: {teach.Name} | Surname: {teach.Surname} | Salary: {teach.Salary} | Bday: {teach.Birthday}");
            }

        }

        public static void MenuAddStudent()
        {
            try
            {
                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter surname:");
                string surname = Console.ReadLine();

                Console.WriteLine("Enter grade:");
                double grade = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter birthday (MM/dd/yyyy):");
                DateTime birthDay = DateTime.Parse(Console.ReadLine());

                classroomService.AddStudent(name, surname, grade, birthDay);

                Console.WriteLine("Added student successfuly!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, error. {ex.Message}");
            }
        }

        public static void MenuAddTeacher()
        {
            Console.WriteLine("Add teacher name:");
            string name = Console.ReadLine() ;

            Console.WriteLine("Add teacher surname");
            string surname = Console.ReadLine() ;

            Console.WriteLine("Add teacher salary:");
            double salary = double.Parse(Console.ReadLine());

            Console.WriteLine("Add teacher Birthday (MM/dd/yyyy):");
            DateOnly bday = DateOnly.Parse(Console.ReadLine());

            classroomService.AddTeacher(name,surname, salary, bday);
            Console.WriteLine("Succesfully added!");


        }
        public static void MenuUpdateStudent()
        {
            try
            {
                Console.WriteLine("Enter ID:");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter surname:");
                string surname = Console.ReadLine();

                Console.WriteLine("Enter grade:");
                double grade = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter birthday (MM/dd/yyyy):");
                DateTime birthDay = DateTime.Parse(Console.ReadLine());

                classroomService.UpdateStudent(id, name, surname, grade, birthDay);

                Console.WriteLine("Updated student successfuly!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, error. {ex.Message}");
            }
        }

        public static void MenuUpdateTeacher()
        {
            try
            {
                Console.WriteLine("Please enter ID which you want updating:");
                var id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter new teacher name to update:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter new teacher surname to update:");
                string surname = Console.ReadLine();

                Console.WriteLine("Enter new teacher salary to update:");
                double salary = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter new teacher birthday to update:");
                DateOnly birthday = DateOnly.Parse(Console.ReadLine());

                classroomService.UpdateTeacher(id, name, surname, salary, birthday);

                Console.WriteLine("Information has been updated");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error!" + ex.Message);
            }

        }
        public static void MenuRemoveStudent()
        {
            try
            {
                Console.WriteLine("Enter student's ID:");
                int id = int.Parse(Console.ReadLine());

                classroomService.RemoveStudent(id);

                Console.WriteLine("Deleted student successfuly!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, error. {ex.Message}");
            }
        }
        public static void MenuRemoveTeacher()
        {
            try
            {
                Console.WriteLine("Enter ID for deleting information:");
                int del = int.Parse(Console.ReadLine());

                classroomService.RemoveTeacher(del);

                Console.WriteLine("Information has been deleted!");


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error!{ex.Message}");

            }



        }
        public static void MenuFindStudentsByName()
        {
            try
            {
                Console.WriteLine("Enter name for search:");
                string name = Console.ReadLine();

                var foundStudents = classroomService.FindStudentsByName(name);

                if (foundStudents.Count == 0)
                {
                    Console.WriteLine("No students found.");
                    return;
                }

                foreach (var student in foundStudents)
                {
                    Console.WriteLine($"Id: {student.Id} | Name: {student.Name} | Surname: {student.Surname} | Grade: {student.Grade} | BDay: {student.Birthday}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, error. {ex.Message}");
            }
        }
        public static void MenuFindTeachersByName()
        {
            try
            {
                Console.WriteLine("Enter name for search:");
                string name = Console.ReadLine() ;

                var foundTeacher = classroomService.FindTeacherByName(name);
                if(foundTeacher.Count == 0)
                {
                    Console.WriteLine("No teacher found!");
                    return;
                }
                foreach(var item in foundTeacher)
                {
                    Console.WriteLine($"Id: {item.Id} | Name: {item.Name} | Surname: {item.Surname} | Salary: {item.Salary} | BDay: {item.Birthday}");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex.Message}");
            }
            
        }

        public static void MenuSearchStudentsByBday()
        {
            try
            {
                Console.WriteLine("Enter minimum date (MM/dd/yyyy):");
                DateTime minBday = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter maximum date (MM/dd/yyyy):");
                DateTime maxBday = DateTime.Parse(Console.ReadLine());

                var foundStudents = classroomService.SearchStudentsByBday(minBday, maxBday);

                if (foundStudents.Count == 0)
                {
                    Console.WriteLine("No students found.");
                    return;
                }

                foreach (var student in foundStudents)
                {
                    Console.WriteLine($"Id: {student.Id} | Name: {student.Name} | Surname: {student.Surname} | Grade: {student.Grade} | BDay: {student.Birthday}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, error. {ex.Message}");
            }
        }
        public static void MenuSearchTeachersByday()
        {

            try
            {
                Console.WriteLine("Enter minDate for search (MM/dd/yyyy):");
                DateOnly minDate = DateOnly.Parse(Console.ReadLine());

                Console.WriteLine("Enter maxDate for search (MM/dd/yyyy):");
                DateOnly maxDate = DateOnly.Parse(Console.ReadLine());


                var foundteacher = classroomService.SearchTeachersByBday(minDate, maxDate);

                if (foundteacher.Count == 0)
                {
                    Console.WriteLine("Not found!");
                }
                foreach (var teach in foundteacher)
                {
                    Console.WriteLine($"Id: {teach.Id} | Name: {teach.Name} | Surname: {teach.Surname} | Grade: {teach.Salary} | BDay: {teach.Birthday}\"");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error! {ex.Message}");
            }
        }
    }
}
