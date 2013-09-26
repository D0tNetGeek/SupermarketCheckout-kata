using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketCheckout.ItemPriceRules;

namespace SupermarketCheckout
{
    public class Checkout : ICheckout
    {
        private readonly IEnumerable<IItemPriceRule> _itemPriceRules;

        private readonly List<char> _scannedItems;

        public Checkout()
        {
            var itemPriceRuleFactory = new ItemPriceRuleFactory();
            _itemPriceRules = itemPriceRuleFactory.GetAllItemPriceRules();
            _scannedItems = new List<char>();
        }

        public void Scan(char item)
        {
            _scannedItems.Add(item);
        }

        public decimal CalculateTotal()
        {
            decimal total = decimal.Zero;

            var itemsLeft = new List<char>(_scannedItems);

            foreach (var itemPriceRule in _itemPriceRules)
            {
                total += itemPriceRule.CalculatePrice(itemsLeft); 
            }

            if (itemsLeft.Count != 0)
            {
                throw new ApplicationException("Invalid items: " + string.Join(", ", itemsLeft));
            }

            return total;
        }

    }
}
