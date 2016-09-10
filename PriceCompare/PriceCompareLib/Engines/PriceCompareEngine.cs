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
    public class PriceCompareEngine
    {
        public IEnumerable<IItemsAccess> ItemsAccessInstances { get; } =
            from t in Assembly.GetExecutingAssembly().GetTypes()
            where t.GetInterfaces().Contains(typeof(IItemsAccess))
                  && t.GetConstructor(Type.EmptyTypes) != null
            select Activator.CreateInstance(t) as IItemsAccess;

        private readonly CatalogAccessor _catalogAccessor = new CatalogAccessor();
        public List<Product> ProductList => _catalogAccessor.GetProducts();


        public Dictionary<string, int> SelectedItems = new Dictionary<string, int>();

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
        internal Item GetItem(string itemCode, string chainId)
        {
            return (from inst in ItemsAccessInstances
                    where inst.GetChainId().Equals(chainId)
                    select inst.GetItem(itemCode)).FirstOrDefault();
        }
        internal Supplier GetSupplier(string chainId)
        {
            return ItemsAccessInstances.
                Select(inst => inst.GetSupplier()).
                FirstOrDefault(supplier => supplier.ChainId.Equals(chainId));
        }
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
