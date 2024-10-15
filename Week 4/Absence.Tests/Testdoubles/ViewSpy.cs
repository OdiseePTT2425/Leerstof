using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Absence.Tests.Testdoubles
{
    internal class ViewSpy : IView
    {
        public bool IsAskForStudentCalled { get; private set; } = false;
        public Student AskForStudent()
        {
            // Onthou: de methode is opgeroepen en op de console zijn onderstaande gegevens ingevuld
            IsAskForStudentCalled = true;
            return new Student("R1", "John", "Doe");
        }
    }
}
