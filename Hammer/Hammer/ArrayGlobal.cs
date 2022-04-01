using Hammer.Models;

namespace Hammer
{
    public static class ArrayGlobal
    {
        public static Product[] Products;

        public static Product[] AddedProducts
        {
            get => Products;
            set => Products = value;
        }
    }
}