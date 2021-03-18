using System;
using StudentManagement.Models;

namespace StudentManagement
{
    class Program
    {
        static void Main(string[] args)
        {

            School school = new School();
            StudentManagementSystem studentManagementSystem = new StudentManagementSystem(school);
            studentManagementSystem.GetSchoolName();
        }
    }
}

