using FinancialDataAnalysis_System.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialDataAnalysis_System
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        {

        }
        public DbSet<Finance> Finances { get; set; }
        public DbSet<Organization> Organizations { get; set; }
    }
}