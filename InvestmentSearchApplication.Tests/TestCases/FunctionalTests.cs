
using InvestmentSearchApplication.BusinessLayer.Interfaces;
using InvestmentSearchApplication.BusinessLayer.Services;
using InvestmentSearchApplication.BusinessLayer.ViewModels;
using InvestmentSearchApplication.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace InvestmentSearchApplication.Tests.TestCases
{
    public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IInvestmentSearchService _investmentSearch;
        public readonly Mock<IInvestmentSearchRepository> investmentsearch = new Mock<IInvestmentSearchRepository>();

        private readonly User _User;
        private readonly UserViewModel _UserView;
        private readonly Stock _Stock;
        private readonly SWOTAnalysis _Swot;
        private readonly Rating _Rating;
        private readonly List<Stock> _StockList;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
            _investmentSearch = new InvestmentSearchService(investmentsearch.Object);

            _output = output;

            _Rating = new Rating
            {
                StockId = 1,
                OverallRating = 4.5m,
                OwnershipReviewsCount = 20,
                ValuationReviewsCount = 15,
                EfficiencyReviewsCount = 10,
                FinancialsReviewsCount = 18
            };

            // Creating a false object for Stock
            _Stock = new Stock
            {
                Name = "Example Stock",
                CurrentTradingPrice = 100.50m,
                ClosingPrice = 99.80m,
                TodayHigh = 105.20m,
                TodayLow = 98.50m,
                FiftyTwoWeekLow = 80.30m,
                FiftyTwoWeekHigh = 110.60m,
                FaceValue = 10.00m,
                NumberOfShares = 100000,
                MarketCapitalization = 10000000.00m,
                Cash = 5000000.00m,
                Debt = 2000000.00m,
                EnterpriseValue = 8000000.00m,
                DividendYield = 0.03m
            };

            // Creating a false object for SWOTAnalysis
            _Swot = new SWOTAnalysis
            {
                StockId = 1,
                Strengths = "Strong brand presence",
                Weaknesses = "High debt",
                Opportunities = "Expansion into new markets",
                Threats = "Intense competition"
            };

            // Creating a false object for User
            _UserView = new UserViewModel
            {
                Email = "example@example.com",
                Password = "examplepassword"
            };

            _StockList = new List<Stock>
            {
                new Stock
                {
                    Name = "Example Stock 1",
                    CurrentTradingPrice = 100.50m,
                    ClosingPrice = 99.80m,
                    TodayHigh = 105.20m,
                    TodayLow = 98.50m,
                    FiftyTwoWeekLow = 80.30m,
                    FiftyTwoWeekHigh = 110.60m,
                    FaceValue = 10.00m,
                    NumberOfShares = 100000,
                    MarketCapitalization = 10000000.00m,
                    Cash = 5000000.00m,
                    Debt = 2000000.00m,
                    EnterpriseValue = 8000000.00m,
                    DividendYield = 0.03m
                },
                new Stock
                {
                    Name = "Example Stock 2",
                    CurrentTradingPrice = 80.20m,
                    ClosingPrice = 79.50m,
                    TodayHigh = 85.10m,
                    TodayLow = 78.30m,
                    FiftyTwoWeekLow = 70.40m,
                    FiftyTwoWeekHigh = 90.20m,
                    FaceValue = 5.00m,
                    NumberOfShares = 50000,
                    MarketCapitalization = 6000000.00m,
                    Cash = 3000000.00m,
                    Debt = 1000000.00m,
                    EnterpriseValue = 4000000.00m,
                    DividendYield = 0.02m
                },
                // Add more stock objects as needed
            };

        }


        [Fact]
        public async Task<bool> Testfor_UserLogin()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                investmentsearch.Setup(repo => repo.UserLogin(_UserView)).ReturnsAsync(true);
                var result = await _investmentSearch.UserLogin(_UserView);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        [Fact]
        public async Task<bool> Testfor_SearchStock()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                investmentsearch.Setup(repo => repo.SearchStock(_Stock.Name)).ReturnsAsync(_StockList);
                var result = await _investmentSearch.SearchStock(_Stock.Name);
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");

            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_GetStockDetailsByID()
        {
            //Arrange
            var res = false;
            int id = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                investmentsearch.Setup(repo => repo.GetStockDetailsById(_Stock.Id)).ReturnsAsync(_Stock);
                var result = await _investmentSearch.GetStockDetailsById(_Stock.Id);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

      
    }
}