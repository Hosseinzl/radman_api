using Application.interfaces;
using Application.Model;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditController : Controller
    {
        private readonly ICreditRepository _customerPortfolioRepository;
        public CreditController(ICreditRepository customerPortfolioRepository)
        {
            _customerPortfolioRepository = customerPortfolioRepository;
        }

        //[Authorize]
        [HttpGet("GetCustomerPortfolio")]
        [ProducesResponseType(200, Type = typeof(Credit))]
        public IActionResult GetCustomerPortfolio()
        {
            var customerPortfolio = _customerPortfolioRepository.GetCustomerPortfolio(2);
            return Ok(customerPortfolio);
        }
    }
}
