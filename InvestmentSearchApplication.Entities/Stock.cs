using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvestmentSearchApplication.Entities
{
    public class Stock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string Name { get; set; }
        public decimal CurrentTradingPrice { get; set; }
        public decimal ClosingPrice { get; set; }
        public decimal TodayHigh { get; set; }
        public decimal TodayLow { get; set; }
        public decimal FiftyTwoWeekLow { get; set; }
        public decimal FiftyTwoWeekHigh { get; set; }
        public decimal FaceValue { get; set; }
        public int NumberOfShares { get; set; }
        public decimal MarketCapitalization { get; set; }
        public decimal Cash { get; set; }
        public decimal Debt { get; set; }
        public decimal EnterpriseValue { get; set; }
        public decimal DividendYield { get; set; }
    }
}
