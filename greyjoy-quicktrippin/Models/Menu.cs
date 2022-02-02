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

        public void runAddDistrictSales()
        {
            bool correctInput = false;
            var districtInput = Console.ReadLine();
            var parsedDistrict = 0;
            var parsedStore = 0;
            District selectedDistrict = new District();
            Store selectedStore = new Store(0,0,0);


            while (!correctInput)
            {
                Console.WriteLine("Enter District Number");
                var input = Console.ReadLine();
                bool intCheck = int.TryParse(districtInput, out parsedDistrict);
                if (intCheck)
                {
                    var district = QuikTrip.Districts.Where(d => d.DistrictNumber == parsedDistrict);
                    if (district.Count() == 1)
                    {
                        var disList = district.ToList();
                        selectedDistrict.DistrictNumber = disList[0].DistrictNumber;
                        correctInput = true;
                    }
                }
            }

            correctInput = false;

            while (!correctInput)
            {
                Console.WriteLine("Enter Store Number");
                var storeInput = Console.ReadLine();
                bool intCheck = int.TryParse(storeInput, out parsedStore);
                if (intCheck)
                {
                    var storeList = selectedDistrict.StoresList.Where(s => s.StoreNum == parsedStore);
                    if (storeList.Count() == 1)
                    {
                        var storeList1 = storeList.ToList();
                        selectedStore = storeList1[0];
                        correctInput = true;
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
                    }
                }
                else
                {
                    Console.WriteLine("Enter New District Number:");
                    var newNumber = Console.ReadLine();
                }
                
            }

        }
    }
}
