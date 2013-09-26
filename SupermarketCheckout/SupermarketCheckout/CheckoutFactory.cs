using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckout
{
    public class CheckoutFactory
    {
        private readonly ItemPriceRuleFactory _itemPriceRuleFactory;

        public CheckoutFactory()
        {
            _itemPriceRuleFactory = new ItemPriceRuleFactory();
        }

        public ICheckout CreateCheckout()
        {
            var itemPriceRules = _itemPriceRuleFactory.GetAllItemPriceRules();

            var checkout = new Checkout(itemPriceRules);

            return checkout;
        }
    }
}
