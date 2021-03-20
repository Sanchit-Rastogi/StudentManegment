using System;
using StudentManagement.Models;

namespace StudentManagement
{
    public class StudentManagementSystem
    {
        School school = new School();
        public StudentManagementSystem()
        {
            Initialize();
        }

        private void Initialize()
        {
            GetSchoolName();
        }

        public void GetSchoolName()
        {
            Console.WriteLine("Enter School Name :");
            school.Name = Console.ReadLine();
            MenuOptions();
        }

        public void MenuOptions()
        {
            Console.Clear();
            Console.WriteLine("" +
                "Welcome to " + school.Name + " Student information management\n" +
                "----------------------------------------------------------------\n\n" +
                "1. Add Student.\n" +
                "2. Add Marks For Student.\n" +
                "3. Show Student Progress Card.\n\n" +
                "Please Provide valid input from menu options : ");
            int res = Convert.ToInt32(Console.ReadLine());
            switch (res)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    bool isSuccess = AddStudentMarks();
                    Console.WriteLine(isSuccess ? "Student Marks Are Added Successfully\n" : "Student does not exists\n");
                    break;
                case 3:
                    ProgressCard();
                    break;
                default:
                    Console.WriteLine("Not a valid option!!");
                    break;
            }
            Console.WriteLine("Press Any Key to continue");
            Console.ReadLine();
            MenuOptions();

        }

        public void AddStudent()
        {
            Console.Clear();
            Student student = new Student();
            Console.WriteLine("Enter Student Roll Number :");
            student.RollNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student Name :");
            student.Name = Console.ReadLine();
            school.Students.Add(student);
            Console.WriteLine("Student details are added successfully.\n");
        }

        public bool AddStudentMarks()
        {
            Console.Clear();
            Console.WriteLine("Enter Student Roll Number :");
            int rollNo = Convert.ToInt32(Console.ReadLine());
            try
            {
                var student = school.Students.Find(std => std.RollNo == rollNo);
                if (student == null) return false;
                student.Subjects.Add(GetSubjectMarks("English"));
                student.Subjects.Add(GetSubjectMarks("Maths"));
                student.Subjects.Add(GetSubjectMarks("Science"));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Subject GetSubjectMarks(string subjectName) {
            Subject subject = new Subject();
            Console.WriteLine("Enter Marks Scored in " + subjectName + " : ");
            subject.Marks = Convert.ToInt32(Console.ReadLine());
            subject.Name = subjectName;
            return subject;
        }

        public void ProgressCard()
        {
            Console.Clear();
            Console.WriteLine("Enter Student Roll Number :");
            int rollNo = Convert.ToInt32(Console.ReadLine());
            bool flag = false;
            foreach (var student in school.Students)
            {
                if (student.RollNo == rollNo)
                {
                    flag = true;
                    Console.WriteLine("Student Roll Number : " + student.RollNo);
                    Console.WriteLine("Student Name : " + student.Name + " \n");
                    Console.WriteLine("Student Marks");
                    Console.WriteLine("----------------------------------");
                    int marks = 0;
                    int total = 0;
                    foreach(var sub in student.Subjects)
                    {
                        Console.WriteLine(sub.Name + " : " + sub.Marks.ToString());
                        marks += sub.Marks;
                        total += 100;
                    }
                    Console.WriteLine("---------------------------------- \n");
                    Console.WriteLine("Total Marks : " + marks.ToString());
                    Console.WriteLine("Percentage : " + ((marks/total)*100).ToString());
                    Console.WriteLine("---------------------------------- \n");
                    Console.WriteLine("Press Any Key to continue");
                    Console.ReadLine();
                    MenuOptions();
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine("Student does not exists");
                MenuOptions();
            }
        }
    }
}
