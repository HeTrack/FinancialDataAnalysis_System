using ExcelDataReader;
using FinancialDataAnalysis_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FinancialDataAnalysis_System.Controllers
{
    public class FinanceController : Controller
    {
        private readonly Database _db;
        public FinanceController(Database db)
        {
            _db = db;
        }
        public IActionResult CheckFinance(Organization organization)
        {
            var finance = new Finance
            {
                Date = null,
                Organization = _db.Organizations.FirstOrDefault(rec => rec.ID == organization.ID)
            };
            return View(finance);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckFinance(Organization organization, int? date)
        {
            if (date == null)
            {
                return View();
            }
            else
            {
                var _finance = _db.Finances.FirstOrDefault(rec => rec.OrganizationID == organization.ID && rec.Date == date);
                _finance.Organization = _db.Organizations.FirstOrDefault(rec => rec.ID == organization.ID);
                //finance.
                return View(_finance);
            }

        }

        public IActionResult LoadFinance(int id)
        {
            var organization = _db.Organizations.FirstOrDefault(rec => rec.ID == id);
            return View(organization);
        }

        [HttpPost]
        public IActionResult LoadFinance(Organization organization, IFormFile fileExcel1, IFormFile fileExcel2)
        {
            DataTable dataTable1, dataTable2;
            using (var stream1 = new MemoryStream())
            {
                fileExcel1.CopyToAsync(stream1);
                stream1.Position = 0;
                var reader = ExcelReaderFactory.CreateReader(stream1);
                DataSet dataSet = reader.AsDataSet();
                dataTable1 = dataSet.Tables[0];
            };
            using (var stream2 = new MemoryStream())
            {
                fileExcel2.CopyToAsync(stream2);
                stream2.Position = 0;
                var reader = ExcelReaderFactory.CreateReader(stream2);
                DataSet dataSet = reader.AsDataSet();
                dataTable2 = dataSet.Tables[0];
            };

            Finance _finance = new()
            {
                OrganizationID = organization.ID,
                Organization = _db.Organizations.FirstOrDefault(rec => rec.ID == organization.ID),
                Date = Convert.ToInt32(dataTable1.Rows[12][45].ToString() + dataTable1.Rows[12][49].ToString()),
                // Коэффициент абсолютной ликвидности = (1250 + 1240) / 1500
                AbsoluteLiquid = Math.Round((Convert.ToDouble(dataTable1.Rows[53][57] == DBNull.Value ? 0 : dataTable1.Rows[53][57].ToString()) + 
                Convert.ToDouble(dataTable1.Rows[52][57] == DBNull.Value ? 0 : dataTable1.Rows[52][57].ToString())) / 
                Convert.ToDouble(dataTable1.Rows[83][57] == DBNull.Value ? 0 : dataTable1.Rows[83][57].ToString()), 2),
                // Коэффициент текущей ликвидности = 1200 / 1500
                CurrentLiquid = Math.Round(Convert.ToDouble(dataTable1.Rows[55][57] == DBNull.Value ? 0 : dataTable1.Rows[55][57].ToString()) / 
                Convert.ToDouble(dataTable1.Rows[83][57] == DBNull.Value ? 0 : dataTable1.Rows[83][57].ToString()), 2),
                // Коэффициент быстрой ликвидность = (1230 + 1240 + 1250) / (1510 + 1520 + 1550)
                FastLiquid = Math.Round((Convert.ToDouble(dataTable1.Rows[51][57] == DBNull.Value ? 0 : dataTable1.Rows[51][57].ToString())
                + Convert.ToDouble(dataTable1.Rows[52][57] == DBNull.Value ? 0 : dataTable1.Rows[52][57].ToString()) 
                + Convert.ToDouble(dataTable1.Rows[53][57] == DBNull.Value ? 0 : dataTable1.Rows[53][57].ToString())) / 
                (Convert.ToDouble(dataTable1.Rows[77][57] == DBNull.Value ? 0 : dataTable1.Rows[77][57].ToString()) 
                + Convert.ToDouble(dataTable1.Rows[79][57] == DBNull.Value ? 0 : dataTable1.Rows[79][57].ToString()) 
                + Convert.ToDouble(dataTable1.Rows[82][57] == DBNull.Value ? 0 : dataTable1.Rows[82][57].ToString())), 2),
                // Рентабельности продаж = 2200 / 2110
                SaleProfit = Math.Round(Convert.ToDouble(dataTable2.Rows[22][63] == DBNull.Value ? 0 : dataTable2.Rows[22][63].ToString()) / 
                Convert.ToDouble(dataTable2.Rows[17][63] == DBNull.Value ? 0 : dataTable2.Rows[17][63].ToString()), 2),
                // Рентабельности активов = 2400 / 1600
                ActiveProfit = Math.Round(Convert.ToDouble(dataTable2.Rows[33][63] == DBNull.Value ? 0 : dataTable2.Rows[33][63].ToString()) / 
                Convert.ToDouble(dataTable1.Rows[56][57] == DBNull.Value ? 0 : dataTable1.Rows[56][57].ToString()), 2),
                // Рентабельность внеоборотных средств = 2400 / 1100
                VneoborotProfit = Math.Round(Convert.ToDouble(dataTable2.Rows[33][63] == DBNull.Value ? 0 : dataTable2.Rows[33][63].ToString()) / 
                Convert.ToDouble(dataTable1.Rows[47][57] == DBNull.Value ? 0 : dataTable1.Rows[47][57].ToString()), 2),
                // Рентабельность собственного капитала = 2400 / 2 / (1300 + 1530)
                CapitalProfit = Math.Round(Convert.ToDouble(dataTable2.Rows[33][63] == DBNull.Value ? 0 : dataTable2.Rows[33][63].ToString()) / 2 / 
                (Convert.ToDouble(dataTable1.Rows[70][57] == DBNull.Value ? 0 : dataTable1.Rows[70][57].ToString()) 
                + Convert.ToDouble(dataTable1.Rows[80][57] == DBNull.Value ? 0 : dataTable1.Rows[80][57].ToString())), 2),
                // Коэффициент Автономии = 1300 / 1700
                Avtonomia = Math.Round(Convert.ToDouble(dataTable1.Rows[70][57] == DBNull.Value ? 0 : dataTable1.Rows[70][57].ToString()) / 
                Convert.ToDouble(dataTable1.Rows[84][57] == DBNull.Value ? 0 : dataTable1.Rows[84][57].ToString()), 2),
                // Коэффициент Мобильности оборотных активов = (1240 + 1250) / 1200
                MobilActive = Math.Round((Convert.ToDouble(dataTable1.Rows[52][57] == DBNull.Value ? 0 : dataTable1.Rows[52][57].ToString()) 
                + Convert.ToDouble(dataTable1.Rows[53][57] == DBNull.Value ? 0 : dataTable1.Rows[53][57].ToString())) / 
                Convert.ToDouble(dataTable1.Rows[55][57] == DBNull.Value ? 0 : dataTable1.Rows[55][57].ToString()), 2),
                // Коэффициент маневренности собственного капитала = (1300 - 1100) / 1300
                ManevrCapital = Math.Round((Convert.ToDouble(dataTable1.Rows[70][57] == DBNull.Value ? 0 : dataTable1.Rows[70][57].ToString()) - 
                Convert.ToDouble(dataTable1.Rows[47][57] == DBNull.Value ? 0 : dataTable1.Rows[47][57].ToString())) / 
                Convert.ToDouble(dataTable1.Rows[70][57] == DBNull.Value ? 0 : dataTable1.Rows[70][57].ToString()), 2),
                // Коэффициент соотношения заём.и собств.Капитала = (1400 + 1500) / 1300
                ZaemAndCapital = Math.Round((Convert.ToDouble(dataTable1.Rows[76][57] == DBNull.Value ? 0 : dataTable1.Rows[76][57].ToString()) 
                + Convert.ToDouble(dataTable1.Rows[83][57] == DBNull.Value ? 0 : dataTable1.Rows[83][57].ToString())) / 
                Convert.ToDouble(dataTable1.Rows[70][57] == DBNull.Value ? 0 : dataTable1.Rows[70][57].ToString()), 2),
                // Коэффициент Обеспечения оборотных средств собств.оборотными средствами = (1300 - 1100) / 1200
                ObespOborotSredstv = Math.Round((dataTable1.Rows[70][57] == DBNull.Value ? 0 : Convert.ToDouble(dataTable1.Rows[70][57].ToString()) - 
                Convert.ToDouble(dataTable1.Rows[47][57] == DBNull.Value ? 0 : dataTable1.Rows[47][57].ToString())) / 
                Convert.ToDouble(dataTable1.Rows[55][57] == DBNull.Value ? 0 : dataTable1.Rows[55][57].ToString()), 2),
                // Коэффициент Z – показатель 
                Zrate = Math.Round(0.717 * Convert.ToDouble(dataTable1.Rows[55][57] == DBNull.Value ? 0 : dataTable1.Rows[55][57].ToString()) / 
                Convert.ToDouble(dataTable1.Rows[47][57] == DBNull.Value ? 0 : dataTable1.Rows[47][57].ToString()) 
                + 0.847 * Convert.ToDouble(dataTable1.Rows[69][57] == DBNull.Value ? 0 : dataTable1.Rows[69][57].ToString()) / 
                Convert.ToDouble(dataTable1.Rows[47][57] == DBNull.Value ? 0 : dataTable1.Rows[47][57].ToString()) 
                + 3.107 * Convert.ToDouble(dataTable2.Rows[28][63] == DBNull.Value ? 0 : dataTable2.Rows[28][63].ToString()) / 
                Convert.ToDouble(dataTable1.Rows[47][57] == DBNull.Value ? 0 : dataTable1.Rows[47][57].ToString()) 
                + 0.42 * Convert.ToDouble(dataTable1.Rows[70][57] == DBNull.Value ? 0 : dataTable1.Rows[70][57].ToString()) / 
                (Convert.ToDouble(dataTable1.Rows[76][57] == DBNull.Value ? 0 : dataTable1.Rows[76][57].ToString())
                + Convert.ToDouble(dataTable1.Rows[83][57] == DBNull.Value ? 0 : dataTable1.Rows[83][57].ToString())) 
                + 0.998 * Convert.ToDouble(dataTable2.Rows[17][63] == DBNull.Value ? 0 : dataTable2.Rows[17][63].ToString()) / 
                Convert.ToDouble(dataTable1.Rows[47][57] == DBNull.Value ? 0 : dataTable1.Rows[47][57].ToString()), 2)
            };
            _db.Finances.Add(_finance);
            _db.SaveChanges();
            return View("CheckFinance", _finance);
        }
    }
}
