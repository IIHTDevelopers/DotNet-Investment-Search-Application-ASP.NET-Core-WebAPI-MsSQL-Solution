using InvestmentSearchApplication.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentSearchApplication.DataLayer
{
    public class InvestmentSearchDbContext : DbContext
    {
        public InvestmentSearchDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        public DbSet<SWOTAnalysis> SwotAnalyses { get; set; }

        public DbSet<Rating> Ratings { get; set; }

    }

}