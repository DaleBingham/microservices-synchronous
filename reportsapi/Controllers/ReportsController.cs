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
                Report r = await GetSale(id); 
                if (r != null)
                    return Json (r);
                else
                    return NotFound();
            }
            catch (Exception ex) {
                // log the exception
                return BadRequest(ex.Message);
            }
        }

        private async Task<List<Report>> GetSales() {
            List<Report> reports =new List<Report>();
            Report r;
            // get the list of sales
            List<Sale> sales = GetData<List<Sale>>(Environment.GetEnvironmentVariable("salesapi_baseurl")).Result;
            foreach (Sale s in sales) {
                r = new Report();
                // for each sale, call the GetSale(string saleid) to fill each report
                r = await GetSale(s.id);
                // add each report to the list if a valid sale
                if (r != null) reports.Add(r);
            }
            // return the reports
            return reports;
        }
    
        private async Task<Report> GetSale(string saleid) {
            Report report = new Report();
            try {
                Task<Sale> s = GetDataById<Sale>(Environment.GetEnvironmentVariable("salesapi_baseurl"), saleid);
                if (s != null && s.Result != null && !string.IsNullOrEmpty(s.Result.id)){
                    report.sale = s.Result;
                }
                else {
                    return null;
                }
            }
            catch (Exception ex) {

            }

            // go get the person/people record for the sale
            try {
                if (!String.IsNullOrEmpty(report.sale.personId)){
                    Task<Person> p = GetDataById<Person>(Environment.GetEnvironmentVariable("peopleapi_baseurl"), report.sale.personId);
                    if (p != null && p.Result != null && p.Result.PersonId != null && !string.IsNullOrEmpty(p.Result.PersonId.ToString())) {
                        report.person = p.Result;
                    }
                }
            }
            catch (Exception ex) {
                //log that the personId is not valid
            }

            // go get the inventory record for the sale
            try {
                if (report.sale.inventoryId > 0){
                    Task<InventoryResult> invResult = GetDataById<InventoryResult>(Environment.GetEnvironmentVariable("inventoryapi_baseurl"), report.sale.inventoryId.ToString());
                    if (invResult != null && invResult.Result != null && invResult.Result.Data != null)
                        report.inventory = invResult.Result.Data;
                }
            }
            catch (Exception ex) {
                //log that the inventoryId is not valid
            }

            // go get the client record for the sale
            try {
                if (!String.IsNullOrEmpty(report.sale.clientId)){
                    Task<Client> c = GetDataById<Client>(Environment.GetEnvironmentVariable("clientapi_baseurl"), report.sale.clientId.ToString());
                    if (c != null && c.Result != null && c.Result.ID > 0){
                        report.client = c.Result;
                    }
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
