using PriceCompareLib.Accessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PriceCompareLib.Modules;

namespace PriceCompareLib.Engines
{
    //Mostly good work - I would wrap this in an interface though, since it could change one day.
    public class PriceCompareEngine
    {
        /*While this will work, consider how debugging this would be a nightmare.
         * Consider that when chaining calls, you would not have indication as to which call has thrown an exception
         * Nor will you have step into and step over functionality at all times.
         * 
         * This is crucial since not all bugs or exceptions are consistent, 
         * Meaning that they can not always be reproduced by incuring the same sequence of system actions)
         */
        public IEnumerable<IItemsAccess> ItemsAccessInstances { get; } =
            from t in Assembly.GetExecutingAssembly().GetTypes()
            where t.GetInterfaces().Contains(typeof(IItemsAccess))
                  && t.GetConstructor(Type.EmptyTypes) != null
            select Activator.CreateInstance(t) as IItemsAccess;

        private readonly CatalogAccessor _catalogAccessor = new CatalogAccessor();
        public List<Product> ProductList => _catalogAccessor.GetProducts();


        public Dictionary<string, int> SelectedItems = new Dictionary<string, int>();

        /*You should rarely use static references- they provide a short term solution
         Create tight coupling between classes and make consuming code less testable since it can not be configured via a constructor or method parameter to receive some dummy data.
             */
        public static readonly Dictionary<Supplier, List<ItemInBasket>> Basket = new Dictionary<Supplier, List<ItemInBasket>>();


        public void UpdateSelectedItem(string keyName, int valueAmount)
        {
            if (SelectedItems.ContainsKey(keyName))
            {
                SelectedItems[keyName] = valueAmount;
            }
            else
            {
                SelectedItems.Add(keyName, valueAmount);
            }
        }

        //Why make this method internal if only this class uses it?
        internal Item GetItem(string itemCode, string chainId)
        {
            return (from inst in ItemsAccessInstances
                    where inst.GetChainId().Equals(chainId)
                    select inst.GetItem(itemCode)).FirstOrDefault();
        }

        //Why make this method internal if only this class uses it?
        internal Supplier GetSupplier(string chainId)
        {
            return ItemsAccessInstances.
                Select(inst => inst.GetSupplier()).
                FirstOrDefault(supplier => supplier.ChainId.Equals(chainId));
        }

        //Wouldn't you be better off with encapsulation?
        public Dictionary<string, int> GetSelectedItems()
        {
            return SelectedItems;
        }


        public Dictionary<string, double> GetTotalPriceDictionary()
        {
            var totalPriceDictionary = new Dictionary<string, double>();

            AddSupplierTotalPrice(totalPriceDictionary);

            return totalPriceDictionary;
        }

        private static void AddSupplierTotalPrice(Dictionary<string, double> totalPriceDictionary)
        {
            Parallel.ForEach(Basket, supplier =>
            {
                var supplierTotalPrice = (from itemInBasket in supplier.Value
                                          let itemPrice = itemInBasket.Item.Price
                                          let itemAmount = itemInBasket.Amount
                                          select itemPrice * itemAmount).Sum();


                totalPriceDictionary.Add(supplier.Key.Name, Math.Round(supplierTotalPrice, 2));
            });
        }


        public void UpdateBasket()
        {
            Basket.Clear();
            foreach (var selItem in SelectedItems)
            {
                var itemName = selItem.Key;
                SearchSelItemInProductList(itemName, selItem);
            }
        }

        private void SearchSelItemInProductList(string itemName, KeyValuePair<string, int> selItem)
        {
            foreach (var product in ProductList
                .Where(product => itemName.Equals(product.Name)))
            {
                CheckProductAltervatives(product, selItem);
                break;
            }
        }

        private void CheckProductAltervatives(Product product, KeyValuePair<string, int> selItem)
        {
            Parallel.ForEach(product.AlternativesList, alternative =>
            {
                var chainId = alternative.ChainId;
                var itemCode = alternative.ItemCode;

                var itemDesc = GetItem(itemCode, chainId);
                var itemInBasket = new ItemInBasket(itemDesc, selItem.Value);
                var supplier = GetSupplier(chainId);
                AddItemToBasket(supplier, itemInBasket);
            });
        }

        private static void AddItemToBasket(Supplier supplier, ItemInBasket itemInBasket)
        {
            AddNewSupplierToBasket(supplier);
            Basket[supplier].Add(itemInBasket);
        }

        private static void AddNewSupplierToBasket(Supplier supplier)
        {
            if (!Basket.ContainsKey(supplier))
            {
                Basket.Add(supplier, new List<ItemInBasket>());
            }
        }
    }
}
