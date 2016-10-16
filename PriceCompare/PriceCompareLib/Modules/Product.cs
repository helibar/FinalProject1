using System.Collections.Generic;

namespace PriceCompareLib.Modules
{
    //Very good model design
    public class Product
    {
        public readonly string Name;
        public readonly List<Alternative> AlternativesList;


        public Product(string name, List<Alternative> alternativesList)
        {
            Name = name;
            AlternativesList = alternativesList;
        }
    }
}
