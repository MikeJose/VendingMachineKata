using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataVM.Library
{
    public class VendingMachine
    {
        public string GetCoinValue(decimal weight)
        {
            switch (weight)
            {
                case 0.176m:
                    return "$0.05";
                case 0.08m:
                    return "$0.10";
                default:
                    return "Error";
            }
        }
    }
}
