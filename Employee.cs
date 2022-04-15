using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    class Employee
    {
        public int Id { get; set; }

        public int Idref { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string FullName => Name + " " + Lastname;

        public string CompanyName { get; set; }

        public string Position { get; set; }
    }
}
