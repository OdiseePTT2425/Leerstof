using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Absence

{
    // Dit houdt bij welke studenten aanwezig/afwezig/gewettigd afwezig waren
    // 1 object per dag
    // Data klasse
    public class AbsenceCheck
    {
        public DateOnly Day { get; set; }
        public List<Student> PresentStudents { get; set; }
        public List<Student> AbsentStudents { get; set; }
        public List<Student> ExcusedStudents { get; set; }

        public AbsenceCheck()
        {
            Day = DateOnly.FromDateTime(DateTime.Now);
            PresentStudents = new List<Student>();
            AbsentStudents = new List<Student>();
            ExcusedStudents = new List<Student>();
        }
    }
}
