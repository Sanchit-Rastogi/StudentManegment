using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    public class Student
    {
        public string Name { get; set; }
        public int RollNo { get; set; }
        public List<Subject> Subjects { get; set; }

        public Student()
        {
            Subjects = new List<Subject>();
        }
    }
}
