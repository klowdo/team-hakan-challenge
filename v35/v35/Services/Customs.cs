using System.Collections.Generic;
using System.Linq;
using v35.Models;

namespace v35.Services
{
    public abstract class Customs
    {
        private readonly List<CustomsRule> _customsRules = new List<CustomsRule>();
        private readonly decimal _regularPrice;

        protected Customs(decimal regularPrice)
        {
            _regularPrice = regularPrice;
        }

        public decimal CalculatePrice(Vehicle vehicle)
        {
            return _customsRules.Aggregate(_regularPrice, (a, t) => t.CalculateNewPrice(a, vehicle));
        }

        public void AddRule(CustomsRule rule) => _customsRules.Add(rule);
    }
}