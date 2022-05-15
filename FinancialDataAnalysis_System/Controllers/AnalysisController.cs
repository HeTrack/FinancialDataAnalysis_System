using FinancialDataAnalysis_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancialDataAnalysis_System.Controllers
{
    public class AnalysisController : Controller
    {
        private readonly Database _db;
        public AnalysisController(Database db)
        {
            _db = db;
        }
        public IActionResult ZAnalysis ()
        {
            ZAnalysis zModel = new()
            {
                Date = null
            };
            return View(zModel);
        }

        [HttpPost]
        public IActionResult ZAnalysis(int date)
        {
            ZAnalysis zModel = new()
            {
                Date = date,
                organizationFinances = _db.Finances.Where(p => p.Date == date).Include(u => u.Organization)

            };
            return View(zModel);
        }

        public IActionResult ParamAnalysis()
        {
            ParamAnalysis paramAnalysis = new()
            {
                Parameter = null
            };
           return View(paramAnalysis);
        }

        [HttpPost]
        public IActionResult ParamAnalysis(ParamAnalysis _paramAnalysis)
        {
            ParamAnalysis paramAnalysis = new()
            {
                Parameter = _paramAnalysis.Parameter,
                MediumLiquid = Math.Round(_db.Finances.Average(p => p.AbsoluteLiquid) + _db.Finances.Average(p => p.CurrentLiquid) + _db.Finances.Average(p => p.FastLiquid), 2),
                MediumRent = Math.Round(_db.Finances.Average(p => p.SaleProfit) + _db.Finances.Average(p => p.ActiveProfit) + _db.Finances.Average(p => p.VneoborotProfit) + _db.Finances.Average(p => p.CapitalProfit), 2),
                MediumFinStable = Math.Round(_db.Finances.Average(p => p.Avtonomia) + _db.Finances.Average(p => p.MobilActive) + _db.Finances.Average(p => p.ManevrCapital) + _db.Finances.Average(p => p.ZaemAndCapital) + _db.Finances.Average(p => p.ObespOborotSredstv), 2),
                organizationFinances = new Dictionary<Organization, double>()
            };
            var tempOrg = _db.Organizations.Include(u => u.Finances);
            if (paramAnalysis.Parameter == "Ликвидность")
            {
                foreach (var org in tempOrg)
                {
                    paramAnalysis.organizationFinances.Add(org, Math.Round(org.Finances.Sum(p => p.AbsoluteLiquid + p.CurrentLiquid + p.FastLiquid), 2));
                }
            }
            else if (paramAnalysis.Parameter == "Рентабельность")
            {
                foreach (var org in tempOrg)
                {
                    paramAnalysis.organizationFinances.Add(org, Math.Round(org.Finances.Sum(p => p.SaleProfit + p.ActiveProfit + p.VneoborotProfit + p.CapitalProfit), 2));
                }
            }
            else
            {
                foreach (var org in tempOrg)
                {
                    paramAnalysis.organizationFinances.Add(org, Math.Round(org.Finances.Sum(p => p.Avtonomia + p.MobilActive + p.ManevrCapital + p.ZaemAndCapital + p.ObespOborotSredstv), 2));
                }
            }
                return View(paramAnalysis);
        }
    }
}
