using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greyjoy_quicktrippin.Models
{
    internal class StoreManager : Employee
    {
        public StoreManager (string name, int empNum, double retail, double gas)
        {
            Name = name;
            EmployeeNum = empNum;
            RetailSales = retail;
            GasSales = gas;
        }
    }
}
