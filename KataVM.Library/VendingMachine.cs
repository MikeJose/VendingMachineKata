using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataVM.Library
{
    public class VendingMachine
    {
        public decimal amountInserted { get; set; }

        public string GetCoinValue(decimal weight)
        {
            switch (weight)
            {
                case 0.088m:
                    return CoinRejected();
                case 0.176m:
                    return TrackAmountEntered(0.05m);
                case 0.08m:
                    return TrackAmountEntered(0.10m);
                case 0.2m:                   
                    return TrackAmountEntered(0.25m);
                default:
                    return CoinRejected();
            }
        }

        public string TrackAmountEntered(decimal coinValue)
        {
            amountInserted += coinValue;
            return amountInserted.ToString("C");
        }

        public string CoinRejected()
        {
            //return coin to slot
            return "INSERT COIN";
        }

        public int ReturnCoins()
        {
            throw new NotImplementedException();
        }
    }
}
