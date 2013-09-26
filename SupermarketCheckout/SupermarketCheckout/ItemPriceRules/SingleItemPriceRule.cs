using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckout.ItemPriceRules
{
    internal class SingleItemPriceRule : IItemPriceRule
    {
        public decimal CalculatePrice(List<char> itemsLeft)
        {
            decimal price = itemsLeft.Where(ItemCodePriceMap.Keys.Contains)
                            .Sum(item => ItemCodePriceMap[item]);

            itemsLeft.RemoveAll(ItemCodePriceMap.Keys.Contains);

            return price;
        }


        private static readonly IReadOnlyDictionary<char, decimal> ItemCodePriceMap
            = new Dictionary<char, decimal>()
            {
                {'A', 50m},
                {'B', 30m},
                {'C', 20m},
                {'D', 15m}
            };
    }
}
