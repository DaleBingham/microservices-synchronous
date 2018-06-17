using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using reportsapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net.Http.Headers;


namespace reportsapi.Controllers
{
    [Route("api/[controller]")]
    public class ReportsController : Controller
    {
        // GET api/reports
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try {
                return Json (await GetSales());
            }
            catch (Exception ex) {
                // log the exception
                return BadRequest(ex.Message);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try {
                return Json (await GetSale(id));
            }
            catch (Exception ex) {
                // log the exception
                return BadRequest(ex.Message);
            }
        }

        private async Task<List<Report>> GetSales() {
            List<Report> reports = new List<Report>();   

            return reports;
        }
        private async Task<Report> GetSale(string saleid) {
            Report report = new Report();   

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Environment.GetEnvironmentVariable("salesapi_baseurl"));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync(saleid);
                if (response.IsSuccessStatusCode)
                {
                    Sale sale = await response.Content.ReadAsAsync<Sale>();
                    report.sale = sale;
                }

            }
            return report;
        }
    }
}
