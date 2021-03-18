using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    public class School
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }

        public School()
        {
            Students = new List<Student>();
        }
    }
}
