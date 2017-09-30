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

        //------------------------------------------

        public Product()
        {

        }

        public Product(string pName, int pID, decimal pPrice)
        {
            Name = pName;
            ID = pID;
            Price = pPrice;
        }
    }
}
