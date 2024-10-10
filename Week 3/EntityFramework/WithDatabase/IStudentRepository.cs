﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithDatabase
{
    internal interface IStudentRepository
    {
        void Add(Student student);
        Student Get(int id);
        List<Student> GetAll();

        void Update(Student student);

        void Delete(int id);
        void Delete(Student student);
    }
}