﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PriceCompareLib.Modules;

namespace PriceCompareLib.Accessors
{
    public interface IItemsAccess
    {
        XElement XElement { get; }
        string GetRootDirectory();
        string GetXml();
        Supplier GetSupplier();
        Dictionary<string, string> GetProductsNameList();
        string GetChainId();
        string GetNameByCode(string code);
        string GetPriceByCode(string code);
        bool IsItemCodeExist(string code);
        Item GetItem(string code);
    }
}
