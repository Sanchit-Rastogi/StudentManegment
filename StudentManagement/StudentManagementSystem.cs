using System;
using StudentManagement.Models;

namespace StudentManagement
{
    public class StudentManagementSystem
    {
        School school;
        public StudentManagementSystem(School school)
        {
            this.school = school;
        }

        public void GetSchoolName()
        {
            Console.WriteLine("Enter School Name :");
            string name = Console.ReadLine();
            school.Name = name;
            DisplayMenuOptions();
        }

        public void DisplayMenuOptions()
        {
            Console.Clear();
            Console.WriteLine("Welcome to "+ school.Name + " Student information management");
            Console.WriteLine("----------------------------------------------------------------\n");
            Console.WriteLine("1. Add Student.");
            Console.WriteLine("2. Add Marks For Student.");
            Console.WriteLine("3. Show Student Progress Card.\n");
            Console.WriteLine("Please Provide valid input from menu options : ");
            int res = Convert.ToInt32(Console.ReadLine());
            switch (res)
            {
                case 1:
                    AddAStudent();
                    break;
                case 2:
                    bool result = AddStudentMarks();
                    if (result)
                    {
                        Console.WriteLine("Student Marks Are Added Successfully\n");
                        Console.WriteLine("Press Any Key to continue");
                        Console.ReadLine();
                        DisplayMenuOptions();
                    }
                    else
                    {
                        Console.WriteLine("Student does not exists\n");
                        Console.WriteLine("Press Any Key to continue");
                        Console.ReadLine();
                        DisplayMenuOptions();
                    }
                    break;
                case 3:
                    ShowProgressCard();
                    break;
                default:
                    Console.WriteLine("Not a valid option!!");
                    break;
            }

        }

        public void AddAStudent()
        {
            Console.Clear();
            Console.WriteLine("Enter Student Roll Number :");
            int rollNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student Name :");
            string name = Console.ReadLine();
            Student student = new Student();
            student.Name = name;
            student.RollNo = rollNo;
            school.Students.Add(student);
            Console.WriteLine("Student details are added successfully.\n");
            Console.WriteLine("Press Any Key to continue");
            Console.ReadLine();
            DisplayMenuOptions();
        }

        public bool AddStudentMarks()
        {
            Console.Clear();
            Console.WriteLine("Enter Student Roll Number :");
            int rollNo = Convert.ToInt32(Console.ReadLine());
            bool flag = false;
            foreach(var student in school.Students)
            {
                if(student.RollNo == rollNo)
                {
                    flag = true;
                    Console.WriteLine("Enter Marks Scored in English :");
                    int english = Convert.ToInt32(Console.ReadLine());
                    Subject eng = new Subject();
                    eng.Marks = english;
                    eng.Name = "English";
                    student.subjects.Add(eng);
                    Console.WriteLine("Enter Marks Scored in Maths :");
                    int maths = Convert.ToInt32(Console.ReadLine());
                    Subject math = new Subject();
                    math.Marks = maths;
                    math.Name = "Maths";
                    student.subjects.Add(math);
                    Console.WriteLine("Enter Marks Scored in Science :");
                    int science = Convert.ToInt32(Console.ReadLine());
                    Subject scs = new Subject();
                    scs.Marks = science;
                    scs.Name = "Science";
                    student.subjects.Add(scs);
                    break;
                }
            }
            return flag;
        }

        public void ShowProgressCard()
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
                    foreach(var sub in student.subjects)
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
                    DisplayMenuOptions();
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine("Student does not exists");
                DisplayMenuOptions();
            }
        }
    }
}
