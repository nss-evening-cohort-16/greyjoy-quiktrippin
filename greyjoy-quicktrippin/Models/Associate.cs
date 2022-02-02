using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greyjoy_quicktrippin.Models
{
    internal class Associate : Employee
    {
        public double RetailSales { get; set; }
        public double GasSales { get; set; }
        public Associate(string name, int empNum, double retail, double gas)
        {
            Name = name;
            EmployeeNum = empNum;
            RetailSales = retail;
            GasSales = gas;
        }
    }
}
