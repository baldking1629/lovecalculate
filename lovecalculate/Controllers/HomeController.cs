using lovecalculate.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace lovecalculate.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Root root)
        {
            //string name = root.firstname + " " + root.secondname;
            return RedirectToAction("About", "Home",root) ;
        }
        public async Task<ActionResult> About(Root root)
        {
            string firstname = root.firstname;
            string secondname = root.secondname;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://the-love-calculator.p.rapidapi.com/love-calculator?fname="+firstname+"&sname="+secondname),
                Headers =
    {
        { "X-RapidAPI-Key", "d317931d34msh05c39424a217125p134a3cjsn3214b19f3e1d" },
        { "X-RapidAPI-Host", "the-love-calculator.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Root ölcüm = JsonConvert.DeserializeObject<Root>(body);
                return View(ölcüm);
            }
        }


    }
}