using Checkout.Core.Models;

namespace Checkout.Core
{
    public class CheckOut(IEnumerable<PricingRule> pricingRules) : ICheckOut
    {
        private readonly List<string> _scannedItems = [];
        private readonly IEnumerable<PricingRule> _pricingRules = pricingRules ??
                                                                  throw new ArgumentNullException(nameof(pricingRules));
        public int GetTotalPrice()
        {
            int totalPrice = 0;

            if (!_scannedItems.Any()) return totalPrice;

            var groupItemsBySku = _scannedItems.GroupBy(s => s);

            foreach (var group in groupItemsBySku)
            {
                var sku = group.Key;
                var count = group.Count();

                var pricingRule = _pricingRules.FirstOrDefault(s => s.Sku == sku);

                if (pricingRule is not null)
                {
                    if (pricingRule.SpecialOffer is not null)
                    {
                        var specialBundle = count / pricingRule.SpecialOffer.Quantity;
                        var remainingItems = count % pricingRule.SpecialOffer.Quantity;

                        totalPrice += (specialBundle * pricingRule.SpecialOffer.SpecialPrice) + (remainingItems * pricingRule.UnitPrice);
                    }
                    else
                    {
                        totalPrice += (count * pricingRule.UnitPrice);
                    }
                }
            }

            return totalPrice;
        }

        public void Scan(string item)
        {
            if (string.IsNullOrWhiteSpace(item)) return;
            _scannedItems.Add(item);
        }
    }
}
