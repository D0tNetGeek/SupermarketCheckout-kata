using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckout.ItemPriceRules
{
    public class ThreeAItemPriceRule : IItemPriceRule
    {
        private const decimal ItemBundlePrice = 130;
        private const decimal ItemsInBundle = 3;
        private const char ItemSku = 'A';

        public decimal CalculatePrice(List<char> itemsLeft)
        {
            var itemCount = itemsLeft.Count(x => x == ItemSku);

            var itemBundles = (int) (itemCount / ItemsInBundle);

            var bundledItems = itemBundles * ItemsInBundle;
            
            for (var i = 0; i < bundledItems; i++)
            {
                itemsLeft.Remove(ItemSku);
            }
            
            var price = itemBundles * ItemBundlePrice;

            return price;
        }
    }
}
