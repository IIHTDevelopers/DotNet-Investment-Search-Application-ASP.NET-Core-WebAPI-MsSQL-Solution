
using InvestmentSearchApplication.BusinessLayer.ViewModels;
using InvestmentSearchApplication.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentSearchApplication.BusinessLayer.Interfaces
{
    public interface IInvestmentSearchService
    {
        Task<bool> UserLogin(UserViewModel model);
        Task<List<Stock>> SearchStock(string stockName);
        Task<object> GetStockDetailsById(int stockId);
    }
}
