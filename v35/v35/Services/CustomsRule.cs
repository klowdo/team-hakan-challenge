using System;
using v35.Models;

namespace v35.Services
{
    public class CustomsRule
    {
        private readonly Func<decimal, Vehicle, decimal> _rule;

        public CustomsRule(Func<decimal, Vehicle, decimal> rule)
        {
            _rule = rule;
        }

        public decimal CalculateNewPrice(decimal currentPrice, Vehicle vehicle)
        {
            return _rule(currentPrice, vehicle);
        }
    }
}