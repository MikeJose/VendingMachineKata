﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataVM.Library
{
    public class VendingMachine
    {
        //Local Variables
        public decimal amountInserted { get; set; }

        Dictionary<int, Product> inventory = new Dictionary<int, Product>();

        //----------------------------------------------------------------

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
            //I would call the user interface method that communicates to the actual coin slot
            //and I would pass it the inserted coin

            return "INSERT COIN";
        }

        public string ReturnCoins()
        {
            //I would call the user interface method that communicates to the actual coin slot
            //and I would pass it the value of amountInserted, so that it would know how
            //much money to release to the coin slot

            amountInserted = 0;

            return "INSERT COIN";
        }

        public string SelectProduct(int productID)
        {
            switch(productID)
            {
                case 1:
                    return "Cola";
                case 2:
                    return "Chips";
                case 3:
                    return "Candy";
                default:
                    return "Error";
            }
        }

        public int LoadMachine(int numCola, int numChips, int numCandy)
        {
            for(int i = 0; i < numCola; i++)
            {
                Product cola = new Product("Cola", 1, 1m);
                inventory.Add(1, cola);
            }

            for (int i = 0; i < numChips; i++)
            {
                Product chips = new Product("Chips", 2, 0.5m);
                inventory.Add(2, chips);
            }

            for (int i = 0; i < numCandy; i++)
            {
                Product candy = new Product("Candy", 3, 0.65m);
                inventory.Add(3, candy);
            }

            return inventory.Count;
        }

        public int ColaInventory()
        {
           
            return 0;
        }
    }
}
