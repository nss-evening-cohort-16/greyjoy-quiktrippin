using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greyjoy_quicktrippin.Models
{
    internal class District
    {
        public List<Store> StoresList = new List<Store>();
        public int DistrictNumber { get; set; }
        public double DistrictTotalRetail { get; set; }
        public double DistrictTotalGas { get; set; }  

        public void DistrictGasTotal(int gasSales)
        {
            Console.WriteLine("Look. A Unicorn.");
        }

        public void DistrictRetailTotal(int retailSales)
        {
            Console.WriteLine("Look. A Unicorn.");
        }
    }
}
