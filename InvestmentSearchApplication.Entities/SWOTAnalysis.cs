using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvestmentSearchApplication.Entities
{
    public class SWOTAnalysis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public int StockId { get; set; } 
        public string Strengths { get; set; }
        public string Weaknesses { get; set; }
        public string Opportunities { get; set; }
        public string Threats { get; set; }
    }
}
