using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckout
{
    public class Checkout : ICheckout
    {
        private char _scannedItem;

        public void Scan(char item)
        {
            _scannedItem = item;
        }

        public decimal CalculateTotal()
        {
            return ItemCodePriceMap[_scannedItem];
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
