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
            report.sale = GetDataById<Sale>(Environment.GetEnvironmentVariable("salesapi_baseurl"), saleid).Result;

            // go get the person/people record for the sale
            try {
                if (!String.IsNullOrEmpty(report.sale.personId)){
                    report.person = GetDataById<Person>(Environment.GetEnvironmentVariable("peopleapi_baseurl"), report.sale.personId).Result;
                }
            }
            catch (Exception ex) {
                //log that the personId is not valid
            }

            // go get the inventory record for the sale
            try {
                if (report.sale.inventoryId > 0){
                    InventoryResult result = GetDataById<InventoryResult>(Environment.GetEnvironmentVariable("inventoryapi_baseurl"), report.sale.inventoryId.ToString()).Result;
                    if (result != null && result.Data != null)
                        report.inventory = result.Data;
                }
            }
            catch (Exception ex) {
                //log that the inventoryId is not valid
            }

            // go get the client record for the sale
            try {
                if (!String.IsNullOrEmpty(report.sale.clientId)){
                    report.client = GetDataById<Client>(Environment.GetEnvironmentVariable("clientapi_baseurl"), report.sale.clientId.ToString()).Result;
                }
            }
            catch (Exception ex) {
                //log that the clientID is not valid
            }
            return report;
        }

        /// this is a generic Get All / List call to other APIs
        private async Task<T> GetData<T>(string baseurl) {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                else
                return default(T);
            }
        }

        /// this is a generic GetById call to other APIs
        private async Task<T> GetDataById<T>(string baseurl, string id) {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "Reports API");

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync(id);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                else
                return default(T);
            }
        }
    }
}
