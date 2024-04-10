
using InvestmentSearchApplication.BusinessLayer.Interfaces;
using InvestmentSearchApplication.BusinessLayer.ViewModels;
using InvestmentSearchApplication.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvestmentSearchApplication.BusinessLayer.Services
{
    public class InvestmentSearchService : IInvestmentSearchService
    {
        private readonly IInvestmentSearchRepository _investmentSearch;
        public InvestmentSearchService(IInvestmentSearchRepository investmentSearchRepository)
        {
            _investmentSearch = investmentSearchRepository;
        }

        public async Task<object> GetStockDetailsById(int id)
        {
            return await _investmentSearch.GetStockDetailsById(id);
        }

        public async Task<List<Stock>> SearchStock(string stockName)
        {
            return await _investmentSearch.SearchStock(stockName);
        }

        public async Task<bool> UserLogin(UserViewModel model)
        {
            return await _investmentSearch.UserLogin(model);
        }
    }
}