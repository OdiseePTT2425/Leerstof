﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les3
{
    internal class Student
    {
        public Student(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - BirthDate.Year;
                if (BirthDate.Date > DateTime.Today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }

        public override string ToString()
        {
            return FirstName + " " + Age;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
    }
}
