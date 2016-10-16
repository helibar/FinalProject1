namespace PriceCompareLib.Modules
{
    //Very good model design
    public class Alternative
    {
        public string ItemCode { get; }
        public string ChainId { get; }

        public Alternative(string chainId, string itemCode)
        {
            ChainId = chainId;
            ItemCode = itemCode;
        }
    }
}