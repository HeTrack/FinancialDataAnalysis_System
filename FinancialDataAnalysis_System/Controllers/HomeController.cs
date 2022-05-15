using ExcelDataReader;
using ClosedXML.Excel;
using FinancialDataAnalysis_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace FinancialDataAnalysis_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Database _db;
        public HomeController(ILogger<HomeController> logger, Database db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Organization> organizations = _db.Organizations; 
            return View(organizations);
        }

        public IActionResult Add()
        {
            return View("CreateOrganization", new Organization());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Organization organization)
        {
            if (ModelState.IsValid)
            {
                Organization tempOrganization = _db.Organizations.FirstOrDefault(rec => rec.Name == organization.Name);
                if(tempOrganization == null)
                {
                    _db.Organizations.Add(organization);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View("CreateOrganization", organization);
            }
        }     
            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}