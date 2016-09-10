
using PriceCompareLib.Engines;
using System.Collections.Generic;
using PriceCompareLib.Modules;

namespace PriceCompareLib.Manager
{
    public class PriceCompareManager
    {
        private readonly PriceCompareEngine _priceCompareEngineengine = new PriceCompareEngine();
        private readonly ExpensiveLowPricesEngine _expensiveLowPricesEngine = new ExpensiveLowPricesEngine();
        public List<Product> ProductList => _priceCompareEngineengine.ProductList;


        public void UpdateItem(string keyName, int valueAmount)
        {
            _priceCompareEngineengine.UpdateSelectedItem(keyName, valueAmount);
        }
        public Dictionary<string, int> GetSelectedItems()
        {
            return _priceCompareEngineengine.GetSelectedItems();
        }

        public Dictionary<string, double> GetFinalPrices()
        {
            _priceCompareEngineengine.UpdateBasket();
            return _priceCompareEngineengine.GetTotalPriceDictionary();
        }

        public Dictionary<Supplier, List<Item>> GetHighLowPrices()
        {
            return _expensiveLowPricesEngine.GetHighestLowestPrices();
        }


    }
}
