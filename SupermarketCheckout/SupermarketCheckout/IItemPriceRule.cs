using System.Collections.Generic;

namespace SupermarketCheckout
{
    internal interface IItemPriceRule
    {
        decimal CalculatePrice(List<char> itemsLeft);
    }
}