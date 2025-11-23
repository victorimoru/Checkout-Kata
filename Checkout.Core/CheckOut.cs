using Checkout.Core.Models;

namespace Checkout.Core
{
    public class CheckOut(IEnumerable<PricingRule> pricingRules) : ICheckOut
    {
        private readonly List<string> _scannedItems = new();
        private readonly IEnumerable<PricingRule> _pricingRules = pricingRules ?? 
                                                                  throw new ArgumentNullException(nameof(pricingRules));
        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void Scan(string item)
        {
            throw new NotImplementedException();
        }
    }
}
