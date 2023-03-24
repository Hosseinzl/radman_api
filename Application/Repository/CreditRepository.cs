using Application.Data;
using Application.interfaces;
using Application.Model;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class CreditRepository : ICreditRepository
    {
        private readonly DataContext _dataContext;

        public CreditRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Credit GetCustomerPortfolio(int id)
        {
            return _dataContext.credits.Include(c => c.portfoloItems).Include(c => c.generalInfo).FirstOrDefault();
        }
    }
}
