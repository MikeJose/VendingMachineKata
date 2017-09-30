using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataVM.Library
{
    class Product
    {
        public string Name { get; set; }

        public int ID { get; set; }

        public decimal Price { get; set; }

        public int NumberInMachine { get; set; }

        //------------------------------------------

        public Product()
        {

        }

        public Product(string pName, decimal pPrice, int num)
        {
            Name = pName;
            Price = pPrice;
            NumberInMachine = num;
        }

        public void AddCount(int numAdded)
        {
            NumberInMachine += numAdded;
        }

        public void SubtractCount(int numSubtracted)
        {
            NumberInMachine -= numSubtracted;
        }
    }
}
