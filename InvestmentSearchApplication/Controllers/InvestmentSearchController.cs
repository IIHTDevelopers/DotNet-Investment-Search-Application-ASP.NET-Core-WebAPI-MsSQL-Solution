using InvestmentSearchApplication.BusinessLayer.Interfaces;
using InvestmentSearchApplication.BusinessLayer.ViewModels;
using InvestmentSearchApplication.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsurancePolicyManagement.Controllers
{
    [ApiController]
    public class InvestmentSearchController : ControllerBase
    {
        private readonly IInvestmentSearchService _investmentSearchService;
        public InvestmentSearchController(IInvestmentSearchService investmentSearch)
        {
            _investmentSearchService = investmentSearch;
        }

        [HttpPost]
        [Route("/api/auth/login")]
        [AllowAnonymous]
        public async Task<IActionResult> UserLogin([FromBody] UserViewModel model)
        {
            var userExists = await _investmentSearchService.UserLogin(model);
            if (userExists ==true)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Success", Message = "User Logged In Successfully!" });
            if (userExists == false)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Invalid User" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong" });
        }

        [HttpGet]
        [Route("/api/stocks/search")]
        [AllowAnonymous]
        public async Task<IActionResult> SearchStock([FromQuery] string stockName)
        {
            var stockExists = await _investmentSearchService.SearchStock(stockName);
            if (stockExists.Count != 0 && stockExists != null)
                return Ok(stockExists);
            if (stockExists.Count==0 || stockExists==null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "No matching stocks found" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong" });
        }

        [HttpGet]
        [Route("/api/stocks/details")]
        [AllowAnonymous]
        public async Task<IActionResult> GetStockById([FromQuery] int stockId)
        {
            var stockExists = await _investmentSearchService.GetStockDetailsById(stockId);
            if (stockExists != null)
                return Ok(stockExists);
            if (stockExists == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "No matching stocks found" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong" });
        }
    }
}