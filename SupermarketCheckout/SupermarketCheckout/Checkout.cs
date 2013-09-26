using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckout
{
    public class Checkout : ICheckout
    {
        private readonly List<char> _scannedItems;

        public Checkout()
        {
            _scannedItems = new List<char>();
        }

        public void Scan(char item)
        {
            _scannedItems.Add(item);
        }

        public decimal CalculateTotal()
        {
            decimal total = decimal.Zero;

            foreach (var item in _scannedItems)
            {
                decimal tmp;
                if (!ItemCodePriceMap.TryGetValue(item, out tmp))
                {
                    throw new ApplicationException("Invalid item: " + item);
                }

                total += tmp;
            }

            return total;
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
