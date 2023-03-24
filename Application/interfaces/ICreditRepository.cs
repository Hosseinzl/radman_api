using Application.Model;

namespace Application.interfaces
{
    public interface ICreditRepository
    {
        Credit GetCustomerPortfolio(int id);
    }
}
