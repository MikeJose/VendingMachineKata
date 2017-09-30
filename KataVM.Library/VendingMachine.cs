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
                case 0.088m:
                    return "Rejected";
                case 0.176m:
                    return "$0.05";
                case 0.08m:
                    return "$0.10";
                case 0.2m:
                    return "$0.25";
                default:
                    return "Error";
            }
        }

        public int TrackAmountEntered(string v)
        {
            throw new NotImplementedException();
        }
    }
}
