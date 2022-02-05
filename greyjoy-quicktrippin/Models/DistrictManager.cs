using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greyjoy_quicktrippin.Models
{
    internal class DistrictManager : Employee
    {
        public override string Position { get => "District Manager"; set { } }
        public DistrictManager(string name, int empNum)
        {
            Name = name;
            EmployeeNum = empNum;

        }
    }
}