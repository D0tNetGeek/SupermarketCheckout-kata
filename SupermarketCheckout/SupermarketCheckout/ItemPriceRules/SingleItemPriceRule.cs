using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckout.ItemPriceRules
{
    internal class SingleItemPriceRule : IItemPriceRule
    {
        private readonly char _itemSku;
        private readonly decimal _price;

        public SingleItemPriceRule(char itemSku, decimal price)
        {
            _itemSku = itemSku;
            _price = price;
        }

        public decimal CalculatePrice(List<char> itemsLeft)
        {
            decimal itemCount = itemsLeft.Count(x => x == _itemSku);

            decimal price = itemCount * _price;

            itemsLeft.RemoveAll(x => x == _itemSku);

            return price;
        }
    }
}
