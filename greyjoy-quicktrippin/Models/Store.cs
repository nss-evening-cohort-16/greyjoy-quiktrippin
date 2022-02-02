using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greyjoy_quicktrippin.Models
{
    internal class Store
    {
        List<string> Employee = new List<string>();

        public int StoreNum { get; set; }
        public double TotalRetail { get; set; }
        public double TotalGas { get; set; }


        public Store (int storeNum, double totalRetail, double totalGas)
        {
            StoreNum = storeNum;
            TotalRetail = totalRetail;
            TotalGas = totalGas;
        }

    }
}
