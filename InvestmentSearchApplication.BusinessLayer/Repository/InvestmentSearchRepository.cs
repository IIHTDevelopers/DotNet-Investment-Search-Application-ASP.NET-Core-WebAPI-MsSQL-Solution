using InvestmentSearchApplication.BusinessLayer.Interfaces;
using InvestmentSearchApplication.BusinessLayer.ViewModels;
using InvestmentSearchApplication.DataLayer;
using InvestmentSearchApplication.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentSearchApplication.BusinessLayer.Repository
{
    public class InvestmentSearchRepository : IInvestmentSearchRepository
    {
        private readonly InvestmentSearchDbContext _dbContext;
        public InvestmentSearchRepository(InvestmentSearchDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> UserLogin(UserViewModel model)
        {
            try
            {
                var data = _dbContext.Users.Where(x => x.Email == model.Email).FirstOrDefault();
                if (data.Email == model.Email && data.Password == model.Password)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Stock>> SearchStock(string stockName)
        {
            try
            {
                var data = await _dbContext.Stocks.Where(x => x.Name == stockName).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object> GetStockDetailsById(int id)
        {
            try
            {
                var stockDetails = await _dbContext.Stocks.Where(x=>x.Id==id)
             .Join(
                 _dbContext.SwotAnalyses,
                 stock => stock.Id,
                 swot => swot.StockId,
                 (stock, swot) => new { Stock = stock, SWOTAnalysis = swot })
             .Join(
                 _dbContext.Ratings,
                 combined => combined.Stock.Id,
                 rating => rating.StockId,
                 (combined, rating) => new 
                 {
                     Stock = combined.Stock,
                     SWOTAnalysis = combined.SWOTAnalysis,
                     Rating = rating
                 })
             .ToListAsync();

                return stockDetails;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}