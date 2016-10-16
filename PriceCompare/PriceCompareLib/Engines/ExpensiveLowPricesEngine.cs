using System.Collections.Generic;
using System.Linq;
using PriceCompareLib.Modules;


namespace PriceCompareLib.Engines
{
    public class ExpensiveLowPricesEngine
    {
        public Dictionary<Supplier, List<Item>> GetHighestLowestPrices()
        {
            var highLowPricesDic = new Dictionary<Supplier, List<Item>>();
            UpdateHighLowPricesDic(highLowPricesDic);
            return highLowPricesDic;
        }

        private static void UpdateHighLowPricesDic(Dictionary<Supplier, List<Item>> highLowPricesDic)
        {
            foreach (var supplier in PriceCompareEngine.Basket)
            {
                var itemInBaskets = supplier.Value.OrderBy(p => p.Item.Price).ToList();
                highLowPricesDic.Add(supplier.Key, new List<Item>());
                UpdateLowPrices(itemInBaskets, highLowPricesDic, supplier);
                UpdateHighPrices(itemInBaskets, highLowPricesDic, supplier);
            }
        }

        private static void UpdateLowPrices(List<ItemInBasket> itemInBaskets, Dictionary<Supplier, List<Item>> highLowPricesDic, KeyValuePair<Supplier, List<ItemInBasket>> supplier)
        {

            /*It is best to avoid magic numbers, such as '3'. 
             * Consider: https://en.wikipedia.org/wiki/Magic_number_(programming)
             */
            for (var i = 0; i < 3; i++)
            {
                if (i >= itemInBaskets.Count)
                {
                    break;
                }
                highLowPricesDic[supplier.Key].Add(itemInBaskets[i].Item);
            }
        }

        private static void UpdateHighPrices(List<ItemInBasket> itemInBaskets, Dictionary<Supplier, List<Item>> highLowPricesDic, KeyValuePair<Supplier, List<ItemInBasket>> supplier)
        {
            /*It is best to avoid magic numbers, such as '3'. 
            * Consider: https://en.wikipedia.org/wiki/Magic_number_(programming)
            */
            for (var i = itemInBaskets.Count - 1; i > itemInBaskets.Count - 4; i--)
            {
                if (i < 0)
                {
                    break;
                }
                highLowPricesDic[supplier.Key].Add(itemInBaskets[i].Item);
            }
        }
    }
}