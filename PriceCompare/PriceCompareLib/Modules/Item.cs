namespace PriceCompareLib.Modules
{
    //Very good model design
    public class Item
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public string UnitOfMeasure { get; private set; }

        public Item(string itemCode, string itemName, double itemPrice, string unitOfMeasure)
        {
            Code = itemCode;
            Name = itemName;
            Price = itemPrice;
            UnitOfMeasure = unitOfMeasure;
        }
    }
}