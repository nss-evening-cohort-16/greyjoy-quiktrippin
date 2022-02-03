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

        Company QuikTrip = new Company();

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

        public int doesDisctrictExist(List<District> list, string itemNumber)
        {
            bool correctInput = false;

                var input = Console.ReadLine();
                int parsedOutput;
                bool intCheck = int.TryParse(input, out parsedOutput);
                if (intCheck)
                {
                    var itemSearch = list.Where(d => d.DistrictNumber == parsedOutput);
                    if (itemSearch.Count() == 1)
                    {
                        var itemList = itemSearch.ToList();
                        correctInput = true;
                        return itemList[0].DistrictNumber;
                    }
                else return -1;

            }
                else return -1;
        }

        public int doesStoreExist(List<Store> list, string itemNumber)
        {
            bool correctInput = false;

                var input = Console.ReadLine();
                int parsedOutput;
                bool intCheck = int.TryParse(input, out parsedOutput);
                if (intCheck)
                {
                    var itemSearch = list.Where(s => s.StoreNum == parsedOutput);
                    if (itemSearch.Count() == 1)
                    {
                        var itemList = itemSearch.ToList();
                        correctInput = true;
                        return itemList[0].StoreNum;
                    }
                else return -1;

            }
                else return -1;
        }

        public int doesEmployeeExist(List<Employee> list, string itemNumber)
        {
            bool correctInput = false;

                var input = Console.ReadLine();
                int parsedOutput;
                bool intCheck = int.TryParse(input, out parsedOutput);
                if (intCheck)
                {
                    var itemSearch = list.Where(e => e.EmployeeNum == parsedOutput);
                    if (itemSearch.Count() == 1)
                    {
                        var itemList = itemSearch.ToList();
                        correctInput = true;
                        return itemList[0].EmployeeNum;
                    }
                else return -1;

            }
                else return -1;
        }

        public void runAddDistrictSales()
        {
            bool correctInput = false;
            int selectedDistrict = -1;
            int selectedStore = -1;
            int selectedEmployee = -1;
            var storeDistrict = QuikTrip.Districts.Where(d => d.DistrictNumber == selectedDistrict).ToList()[0];
            var employeeStore = storeDistrict.StoresList.Where(s => s.StoreNum == selectedStore).ToList()[0];

            while (!correctInput)
            {
                Console.WriteLine("Enter District Number");
                var districtInput = Console.ReadLine();
                int districtNum = doesDisctrictExist(QuikTrip.Districts, districtInput);
                if(districtNum != -1)
                {
                    correctInput = true;
                    selectedDistrict = districtNum;
                }
                else Console.WriteLine("Invalid District Number");
            }

            correctInput = false;

            while (!correctInput)
            {
                Console.WriteLine("Enter Store Number");
                var storeInput = Console.ReadLine();
                int storeNum = doesStoreExist(storeDistrict.StoresList, storeInput);
                if (storeNum != -1)
                {
                    correctInput = true;
                    selectedDistrict = storeNum;
                }
                else Console.WriteLine("Invalid Store Number");
            }

            correctInput = false;

            while (!correctInput)
            {
                Console.WriteLine("Enter Employee Number");
                var employeeInput = Console.ReadLine();
                int EmployeeNum = doesEmployeeExist(employeeStore.Employees, employeeInput);
                if (EmployeeNum != -1)
                {
                    correctInput = true;
                    selectedEmployee = EmployeeNum;
                    Console.WriteLine(EmployeeNum);
                }
                else Console.WriteLine("Invalid Employee Number");
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
            bool correctInput = false;
            var storeOrDistrict = "";

            while (!correctInput)
            {
                Console.WriteLine("New (s)tore or (d)istrict");
                storeOrDistrict = Console.ReadLine();
                if (storeOrDistrict == "d" || storeOrDistrict == "s")
                {
                    correctInput = true;
                }
            }
            
            correctInput=false;

            while (!correctInput)
            {
                if (storeOrDistrict == "d")
                {
                    Console.WriteLine("Enter New District Number:");
                    var newNumber = Console.ReadLine();
                    int parsedNum = 0;
                    bool intcheck = int.TryParse(newNumber, out parsedNum);
                    if (intcheck)
                    {
                        var newDistrict = new District();
                        newDistrict.DistrictNumber = parsedNum;
                        QuikTrip.Districts.Add(newDistrict);
                         correctInput = true;
                        foreach (District district in QuikTrip.Districts)
                        { Console.WriteLine(district.DistrictNumber); }
                    }
                }
                else
                {
                    Console.WriteLine("Enter New District Number:");
                    var newNumber = Console.ReadLine();
                }
                
            }
            Console.ReadLine();
            Console.Clear();
            runMenu();
            

        }
    }
}
