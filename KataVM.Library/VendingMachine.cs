using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataVM.Library
{
    public class VendingMachine
    {
        private decimal amountInserted;

        public decimal GetCoinValue(decimal weight)
        {
            switch (weight)
            {
                case 0.088m:
                    return 0m;
                case 0.176m:
                    return 0.05m;
                case 0.08m:
                    return 0.10m;
                case 0.2m:
                    return 0.25m;
                default:
                    return 0m;
            }
        }

        public string TrackAmountEntered(decimal coinValue)
        {
            amountInserted += coinValue;
            return amountInserted.ToString("C");
        }
    }
}
