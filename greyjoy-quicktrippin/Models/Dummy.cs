using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greyjoy_quicktrippin.Models
{
    internal class Dummy
    {
        public void makeDummy() {
            Company QuikTrip = new Company();



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

            QuikTrip.Districts.Add(District1);
            QuikTrip.Districts.Add(District2);


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
}
}