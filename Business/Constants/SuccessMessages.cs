using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    
    public static class SuccessMessages
    {
        private static string productAdded = "Ürün Eklendi";
        private static string productListed = "Ürünler Listelendi";

        public static string ProductAdded { get => productAdded; set => productAdded = value; }
        public static string ProductListed { get => productListed; set => productListed = value; }

    }
}
