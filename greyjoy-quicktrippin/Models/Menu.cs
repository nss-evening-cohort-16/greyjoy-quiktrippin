using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greyjoy_quicktrippin.Models
{
    internal class Menu
    {
        string _menuText  = @"QuikTrip Management Systems

1. Enter District Sales
2. Generate District Report
3. Add New Employee
4. Add a Store/District
5. Exit";

        public void runMenu()
        {
            bool correctInput = false;
            var parsedInput = 0;

            while (!correctInput)
            {
                Console.WriteLine(_menuText);
                var input = Console.ReadLine();
                correctInput = int.TryParse(input, out parsedInput);
            }

            switch(parsedInput)
            {
                case 1: runAddDistrictSales();
                    break;
                case 2: runGenerateReport();
                    break;
                case 3: runAddEmployee();
                    break;
                case 4: runAddStore();
                    break;
                case 5: break;
            }
        }

        public void runAddDistrictSales()
        {
            bool correctInput = false;
            var districtInput = Console.ReadLine();
            var parsedDistrict = 0;


            while (!correctInput)
            {
                Console.WriteLine("Enter District Number");
                var input = Console.ReadLine();
                bool intCheck = int.TryParse(districtInput, out parsedDistrict);
                if (intCheck)
                {
                    Company.Districts.Where(d => d == parsedDistrict)
                }
            }

            correctInput = false;

            while (!correctInput)
            {
                Console.WriteLine("Enter Store Number");
                var input = Console.ReadLine();
                correctInput = int.TryParse(districtInput, out parsedDistrict);
            }


        }
        public void runGenerateReport()
        {
            Console.WriteLine("placeholder func");
        }
        public void runAddEmployee()
        {
            Console.WriteLine("placeholder func");
        }
        public void runAddStore()
        {
            Console.WriteLine("placeholder func");
        }
    }
}
