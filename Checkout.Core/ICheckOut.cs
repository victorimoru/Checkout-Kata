using Checkout.Core.Models;

namespace Checkout.Core
{
    public interface ICheckOut
    {
        void Scan(string item);
        int GetTotalPrice();
    }
}
