using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvestmentSearchApplication.Entities
{
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int StockId { get; set; }
        public decimal OverallRating { get; set; }
        public int OwnershipReviewsCount { get; set; }
        public int ValuationReviewsCount { get; set; }
        public int EfficiencyReviewsCount { get; set; }
        public int FinancialsReviewsCount { get; set; }
    }
}
