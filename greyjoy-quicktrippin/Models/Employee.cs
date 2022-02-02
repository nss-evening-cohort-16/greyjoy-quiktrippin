using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greyjoy_quicktrippin.Models
{
    internal class Employee
    {
        public string Name { get; set; }
        public int EmployeeNum  { get; set; }   

        public  Employee(string name, int empNum )
        {
            Name = name;
            EmployeeNum = empNum;

        }
    }
}
