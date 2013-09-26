using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketCheckout.ItemPriceRules;

namespace SupermarketCheckout
{
    internal class ItemPriceRuleFactory
    {
        public IItemPriceRule[] GetAllItemPriceRules()
        {
            return new []
                {
                    CreateThreeAItemPriceRule(),
                    CreateTwoBItemPriceRule(),
                    CreateSingleItemPriceRule(), 
                };
        }

        private static SingleItemPriceRule CreateSingleItemPriceRule()
        {
            return new SingleItemPriceRule();
        }

        private IItemPriceRule CreateThreeAItemPriceRule()
        {
            return new MultipleItemPriceRule('A', 130m, 3);
        }

        private IItemPriceRule CreateTwoBItemPriceRule()
        {
            return new MultipleItemPriceRule('B', 45m, 2);
        }
    }
}
