using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PriceCompareLib.Modules;

namespace PriceCompareLib.Accessors
{
    public class CatalogAccessor
    {
        public XElement XmlElement => XElement.Load(GetXml());
        public string GetXml()
        {
            var xmlFile = GetRootDirectory();
            xmlFile += @"\PriceCompareLib\XmlFiles\Catalog.xml";

            return xmlFile;
        }
        public string GetRootDirectory()
        {
            var rootPath = Path.GetDirectoryName(Path.GetDirectoryName(
                System.IO.Path.GetDirectoryName(Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase))));

            return rootPath;
        }

        public List<Product> ProductsList = new List<Product>();

        public List<Product> GetProducts()
        {
            var productsElements = XmlElement.Elements("Product");
            foreach (var product in productsElements)
            {
                var name = product.Element("ProductName")?.Value;
                var alternativeList = GetAlternativeList(product);

                ProductsList.Add(new Product(name, alternativeList));
            }
            return ProductsList;
        }

        private static List<Alternative> GetAlternativeList(XElement product)
        {
            var altElements = product.Elements("Alt");
            var alternativeList = (from alt in altElements
                let chainId = alt.Element("ChainId")?.Value
                let itemCode = alt.Element("ItemCode")?.Value
                select new Alternative(chainId, itemCode)).ToList();
            return alternativeList;
        }
    }
}
