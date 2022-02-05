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

        public Company QuikTrip = new Company();

        public void makeDummy(Company company)
        {

            District District1 = new District()
            {
                DistrictNumber = 1,
                DistrictTotalRetail = 1000,
                DistrictTotalGas = 1500
            };

            District District2 = new District()
            {
                DistrictNumber = 2,
                DistrictTotalRetail = 2000,
                DistrictTotalGas = 3000
            };

            company.Districts.Add(District1);
            company.Districts.Add(District2);


            Store Store12 = new Store(12, 8983.12, 1963.90);
            Store Store8 = new Store(8, 9071.37, 9873.29);
            Store Store2 = new Store(2, 6001.92, 4722.33);
            Store Store21 = new Store(21, 7132.42, 4918.98);

            District1.StoresList.Add(Store12);
            District1.StoresList.Add(Store8);
            District2.StoresList.Add(Store2);
            District2.StoresList.Add(Store21);


            Store12.Employees.Add(
                new Associate("Joe Muay", 1234, 300.33, 45.13)
                );
            Store12.Employees.Add(
                new Associate("Tiffany Thomas", 1122, 566.66, 100.10)
                );

            Store8.Employees.Add(
                new Associate("Johnson Wang", 6688, 123.45, 12.11)
                );
            Store8.Employees.Add(
                new Associate("Murray Longcoat", 21, 800.90, 600.60)
                );

            Store2.Employees.Add(
                new StoreManager("Phillip Pie", 311, 1034.67, 900.41)
                );
            Store2.Employees.Add(
                new StoreManager("Luna Fields", 644, 701.02, 506.39)
                );
            Store21.Employees.Add(
                new StoreManager("Jennifer Blossom", 1003, 999.81, 589.13)
                );
            Store21.Employees.Add(
                new StoreManager("Yancy Mann", 841, 1029.30, 833.33)
                );

        }



        public void runMenu()
        {
            bool correctInput = false;
            var parsedInput = 0;
            makeDummy(QuikTrip);

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
                int parsedOutput;
                bool intCheck = int.TryParse(itemNumber, out parsedOutput);
                if (intCheck)
                {
                    var itemSearch = list.Where(d => d.DistrictNumber == parsedOutput);
                    if (itemSearch.Count() == 1)
                    {
                        var itemList = itemSearch.ToList();
                        return itemList[0].DistrictNumber;
                    }
                else return -1;

            }
                else return -1;
        }

        public int doesStoreExist(List<Store> list, string itemNumber)
        {
                int parsedOutput;
                bool intCheck = int.TryParse(itemNumber, out parsedOutput);
                if (intCheck)
                {
                    var itemSearch = list.Where(s => s.StoreNum == parsedOutput);
                    if (itemSearch.Count() == 1)
                    {
                        var itemList = itemSearch.ToList();
                        return itemList[0].StoreNum;
                    }
                else return -1;

            }
                else return -1;
        }

        public int doesEmployeeExist(List<Employee> list, string itemNumber)
        {
                int parsedOutput;
                bool intCheck = int.TryParse(itemNumber, out parsedOutput);
                if (intCheck)
                {
                    var itemSearch = list.Where(e => e.EmployeeNum == parsedOutput);
                    if (itemSearch.Count() == 1)
                    {
                        var itemList = itemSearch.ToList();
                        return itemList[0].EmployeeNum;
                    }
                else return -1;

            }
                else return -1;
        }

        public void runAddDistrictSales()
        {
            bool correctInput = false;
            District storeDistrict = new District();
            Store employeeStore = new Store();
            Employee employee = new Employee();

            while (!correctInput)
            {
                Console.WriteLine("Enter District Number");
                var districtInput = Console.ReadLine();
                int districtNum = doesDisctrictExist(QuikTrip.Districts, districtInput);
                if(districtNum != -1)
                {
                    storeDistrict = QuikTrip.Districts.Where(d => d.DistrictNumber == districtNum).ToList()[0];
                    correctInput = true;
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
                    employeeStore = storeDistrict.StoresList.Where(s => s.StoreNum == storeNum).ToList()[0];
                }
                else Console.WriteLine("Invalid Store Number");
            }

            correctInput = false;

            while (!correctInput)
            {
                Console.WriteLine("Enter Employee Number");
                var employeeInput = Console.ReadLine();
                int employeeNum = doesEmployeeExist(employeeStore.Employees, employeeInput);
                if (employeeNum != -1)
                {
                    correctInput = true;
                    employee = employeeStore.Employees.Where(s => s.EmployeeNum == employeeNum).ToList()[0]; ;
                }
                else Console.WriteLine("Invalid Employee Number");
            }

            correctInput = false;

            Console.WriteLine("(g)as or (r)etail sales?");
            var input = Console.ReadLine();

            if  (input == "g")
            {
                Console.WriteLine($"{employee.Name}'s Current Gas Sales = {employee.GasSales}");
                while (!correctInput)
                {
                    Console.WriteLine("Enter gas sales:");
                    var gas = Console.ReadLine();
                    int parsedOutput;
                    bool intCheck = int.TryParse(gas, out parsedOutput);
                    if (intCheck)
                    {
                        employee.GasSales += parsedOutput;
                        correctInput = true;
                        Console.WriteLine($"{employee.Name}'s Updated Gas Sales = {employee.GasSales}");
                    }
                }
                
            }

            if (input == "r")
            {
                Console.WriteLine($"{employee.Name}'s Current Retail Sales = {employee.RetailSales}");
                while (!correctInput)
                {
                    Console.WriteLine("Enter retail sales:");
                    var retail = Console.ReadLine();
                    int parsedOutput;
                    bool intCheck = int.TryParse(retail, out parsedOutput);
                    if (intCheck)
                    {
                        employee.RetailSales += parsedOutput;
                        correctInput = true;
                        Console.WriteLine($"{employee.Name}'s Current Retail Sales = {employee.RetailSales}");
                    }
                }
              
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
