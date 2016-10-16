using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompareLib.Modules
{
    //Very good model design
    public class ItemInBasket
    {
        public Item Item { get; }
        public readonly int Amount;

        public ItemInBasket(Item item, int amount)
        {
            Item = item;
            Amount = amount;
        }
    }
}
