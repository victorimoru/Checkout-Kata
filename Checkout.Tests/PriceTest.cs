using Checkout.Core;
using Checkout.Core.Models;

namespace Checkout.Tests
{
    public class Tests
    {
        private IEnumerable<PricingRule> _rules;

        [SetUp]
        public void Setup()
        {
            _rules = [
                        new PricingRule("A", 50, new SpecialOffer(3, 130)),
                        new PricingRule("B", 30, new SpecialOffer(2, 45)),
                        new PricingRule("C", 20),
                        new PricingRule("D", 15)
                     ];
        }

        [Test]
        public void GetTotalPrice_NoItemsScanned_ReturnsZero()
        {
            var checkout = new CheckOut(_rules);
            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(0));
        }

        [Test]
        public void Scan_SingleItem_ReturnsUnitPrice()
        {
            var checkout = new CheckOut(_rules);
            checkout.Scan("A");
            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(50));
        }

        //[Test]
        //public void Scan_SpecialOfferItems_ReturnsDiscountedPrice()
        //{
        //    var checkout = new CheckOut(_rules);
        //    checkout.Scan("A");
        //    checkout.Scan("A");
        //    checkout.Scan("A");

        //    Assert.That(checkout.GetTotalPrice(), Is.EqualTo(130));
        //}

        //[TestCase("AAABBD", 190)]
        //[TestCase("DABABA", 190)]
        //[TestCase("CDBA", 115)]
        //public void CalculatePrice_VariousScenarios_ReturnsExpectedTotal(string items, int expectedTotal)
        //{
        //    var checkout = new CheckOut(_rules);

        //    foreach (var item in items)
        //    {
        //        checkout.Scan(item.ToString());
        //    }

        //    Assert.That(checkout.GetTotalPrice(), Is.EqualTo(expectedTotal));
        //}
    }
}