using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PriceCompareLib.Modules;

namespace PriceCompareLib.Accessors
{
    public class RamiLeviAccessor : IItemsAccess
    {
        public const string ChainId = "7290058140886";
        public const string ChainName = "רמי לוי";

        public XElement XElement => XElement.Load(GetXml());
        public string GetRootDirectory()
        {
            string rootPath = Path.GetDirectoryName(Path.GetDirectoryName(
                System.IO.Path.GetDirectoryName(Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase))));

            return rootPath;
        }
        public string GetXml()
        {
            var xmlFile = GetRootDirectory();
            xmlFile += @"\PriceCompareLib\XmlFiles\PriceFull7290058140886-042-201609020010.xml";

            return xmlFile;
        }
        public Supplier GetSupplier()
        {
            return new Supplier(ChainName, ChainId);
        }
        public Dictionary<string, string> GetProductsNameList()
        {
            var items = from item in XElement.Descendants("Item")
                        select new
                        {
                            Code = item.Element("ItemCode")?.Value,
                            Name = item.Element("ItemName")?.Value,
                        };
            return items.ToDictionary(item => item.Code, item => item.Name);
        }
        public string GetChainId()
        {
            var chainIdElement = (from chain in XElement.Descendants("ChainId")
                                  select chain).SingleOrDefault();
            return chainIdElement?.Value;
        }
        public string GetNameByCode(string code)
        {
            var item = (from i in XElement.Descendants("Item")
                        where i.Element("ItemCode")?.Value == code
                        select i).SingleOrDefault();

            return item?.Element("ItemName")?.Value;
        }
        public string GetPriceByCode(string code)
        {
            var item = (from items in XElement.Descendants("Item")
                        where items.Element("ItemCode")?.Value == code
                        select items).SingleOrDefault();

            return item?.Element("ItemPrice")?.Value;
        }
        public bool IsItemCodeExist(string code)
        {
            var item = (from i in XElement.Descendants("Item")
                        where i.Element("ItemCode")?.Value == code
                        select i).SingleOrDefault();
            return item != null;
        }
        public Item GetItem(string code)
        {
            var item = (from i in XElement.Descendants("Item")
                        where i.Element("ItemCode")?.Value == code
                        select i).SingleOrDefault();

            if (item == null) return null;

            var name = item.Element("ItemName")?.Value;
            var price = item.Element("ItemPrice")?.Value;
            var unitOfMeasure = item.Element("UnitOfMeasure")?.Value;

            return new Item(code, name, double.Parse(price), unitOfMeasure);
        }
    }
}
