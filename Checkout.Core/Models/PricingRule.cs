namespace Checkout.Core.Models
{
    public record PricingRule(string Sku, int UnitPrice, SpecialOffer? SpecialOffer = null);
    public record SpecialOffer(int Quantity, int SpecialPrice);
}
