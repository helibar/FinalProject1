using System.Collections.Generic;

namespace PriceCompareLib.Modules
{
    //Very good model design
    public class Supplier : System.IEquatable<Supplier>
    {
        public  string Name;
        public readonly string ChainId;
        public Supplier(string name, string chainId)
        {
            Name = name;
            ChainId = chainId;
        }
        public override int GetHashCode()
        {
            if (ChainId == null) return 0;
            return ChainId.GetHashCode();
            
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Supplier);
        }
        public bool Equals(Supplier obj)
        {
            return obj != null && obj.ChainId == this.ChainId;
        }
    }
}
