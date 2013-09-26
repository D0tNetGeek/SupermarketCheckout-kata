﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketCheckout.ItemPriceRules;

namespace SupermarketCheckout
{
    internal class ItemPriceRuleFactory
    {
        public IReadOnlyList<IItemPriceRule> GetAllItemPriceRules()
        {
            var rules = new List<IItemPriceRule>();

            rules.Add(CreateThreeAItemPriceRule());
            rules.Add(CreateTwoBItemPriceRule());

            rules.AddRange(CreateSingleItemPriceRules());
            
            return rules;
        }

        private static IEnumerable<IItemPriceRule> CreateSingleItemPriceRules()
        {
            return ItemCodePriceMap.Select(map => new SingleItemPriceRule(map.Key, map.Value));
        }

        private IItemPriceRule CreateThreeAItemPriceRule()
        {
            return new MultipleItemPriceRule('A', 130m, 3);
        }

        private IItemPriceRule CreateTwoBItemPriceRule()
        {
            return new MultipleItemPriceRule('B', 45m, 2);
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
