using EnergyUsageWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using CsvHelper;
using System.Globalization;

namespace EnergyUsageWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            string url = "https://helsinki-openapi.nuuka.cloud/api/v1.0/EnergyData/Daily/ListByProperty?Record=LocationName&SearchString=1000%20Hakaniemen%20kauppahalli&ReportingGroup=Electricity&StartTime=2019-01-01&EndTime=2019-12-31";
            List <energyData> energyDataList = new List<energyData>();
            using(var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    energyDataList = JsonConvert.DeserializeObject<List<energyData>>(apiResponse);
                }
            }
            DateTime dt = DateTime.Now;
            using( var writer = new StreamWriter(dt + ".csv"))
            using(var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(energyDataList);
            }
 
            return View(monthlyData.getData(energyDataList));
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