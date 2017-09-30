using System;
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

        Dictionary<string, Product> inventory = new Dictionary<string, Product>();

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
            int availableCola = 0;
            int availableChips = 0;
            int availableCandy = 0;

            if(numCola >= 1)
            {
                if(inventory.ContainsKey("Cola"))
                {
                    Product cola = inventory["Cola"];
                    cola.AddCount(numCola);

                    availableCola = cola.NumberInMachine;
                }
                else
                {
                    Product cola = new Product("Cola", 1m, numCola);
                    inventory.Add(cola.Name, cola);

                    availableCola = cola.NumberInMachine;
                }
            }
            if(numChips >= 1)
            {
                if(inventory.ContainsKey("Chips"))
                {
                    Product chips = inventory["Chips"];
                    chips.AddCount(numChips);

                    availableChips = chips.NumberInMachine;
                }
                else
                {
                    Product chips = new Product("Chips", 0.5m, numChips);
                    inventory.Add(chips.Name, chips);

                    availableChips = chips.NumberInMachine;
                }
            }
            if(numCandy >= 1)
            {
                if(inventory.ContainsKey("Candy"))
                {
                    Product candy = inventory["Candy"];
                    candy.AddCount(numCandy);

                    availableCandy = candy.NumberInMachine;
                }
                else
                {
                    Product candy = new Product("Candy", 0.65m, numCandy);
                    inventory.Add(candy.Name, candy);

                    availableCandy = candy.NumberInMachine;
                }
            }

            int totalProducts = availableCandy + availableChips + availableCola;

            return totalProducts;
        }

        public int ColaInventory()
        {
            if(inventory.ContainsKey("Cola"))
            {
                Product cola = inventory["Cola"];
                return cola.NumberInMachine;
            }

            return 0;
        }
    }
}
