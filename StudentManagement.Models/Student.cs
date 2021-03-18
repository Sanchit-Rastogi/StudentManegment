using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    public class Student
    {
        public string Name { get; set; }
        public int RollNo { get; set; }
        public List<Subject> subjects { get; set; }

        public Student()
        {
            subjects = new List<Subject>();
        }
    }
}
