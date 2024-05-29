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
            return RedirectToAction("About", "Home", root);
        }
        public ActionResult About(Root root)
        {


            string first = root.firstname.ToUpper();
            int firstlength = root.firstname.Length;
            string second = root.secondname.ToUpper();
            int secondlength = root.secondname.Length;
            string result;
            int LoveCount = 0;

            for (int Count = 0; Count < firstlength; Count++)
            {
                string singleLetter = first.Substring(Count, 1);
                if (singleLetter.Equals("A")) LoveCount += 2;
                if (singleLetter.Equals("E")) LoveCount += 2;
                if (singleLetter.Equals("I")) LoveCount += 2;
                if (singleLetter.Equals("O")) LoveCount += 2;
                if (singleLetter.Equals("U")) LoveCount += 3;
                if (singleLetter.Equals("A")) LoveCount += 1;
                if (singleLetter.Equals("E")) LoveCount += 3;
            }
            for (int Count = 0; Count < secondlength; Count++)
            {
                string singleLetter = second.Substring(Count, 1);
                if (singleLetter.Equals("A")) LoveCount += 2;
                if (singleLetter.Equals("E")) LoveCount += 2;
                if (singleLetter.Equals("I")) LoveCount += 2;
                if (singleLetter.Equals("O")) LoveCount += 2;
                if (singleLetter.Equals("U")) LoveCount += 3;
                if (singleLetter.Equals("A")) LoveCount += 1;
                if (singleLetter.Equals("E")) LoveCount += 3;
            }
            int amount = 0;
            if (LoveCount > 0) amount = 5 - ((firstlength + secondlength) / 2);
            if (LoveCount > 2) amount = 10 - ((firstlength + secondlength) / 2);
            if (LoveCount > 4) amount = 20 - ((firstlength + secondlength) / 2);
            if (LoveCount > 6) amount = 30 - ((firstlength + secondlength) / 2);
            if (LoveCount > 8) amount = 40 - ((firstlength + secondlength) / 2);
            if (LoveCount > 10) amount = 50 - ((firstlength + secondlength) / 2);
            if (LoveCount > 12) amount = 60 - ((firstlength + secondlength) / 2);
            if (LoveCount > 14) amount = 70 - ((firstlength + secondlength) / 2);
            if (LoveCount > 16) amount = 80 - ((firstlength + secondlength) / 2);
            if (LoveCount > 18) amount = 90 - ((firstlength + secondlength) / 2);
            if (LoveCount > 20) amount = 100 - ((firstlength + secondlength) / 2);
            if (LoveCount > 22) amount = 110 - ((firstlength + secondlength) / 2);
            if (firstlength == 0 || secondlength == 0) amount = 0;
            if (amount < 0) amount = 0;
            if (amount > 99) amount = 99;
            root.percentagematch = amount;
            switch (Convert.ToInt32(amount) / 10)
            {
                case 0: root.result = "Kaçın birbirinizden"; break;
                case 1: root.result = "Kaçın birbirinizden"; break;
                case 2: root.result = "Sizden olmaz"; break;
                case 3: root.result = "Başka zamana"; break;
                case 4: root.result = "Bugün değil"; break;
                case 5: root.result = "Birbirinizi tanıyın"; break;
                case 6: root.result = "Birer çay daha için"; break;
                case 7: root.result = "Bu ilişki için çaba harcayın"; break;
                case 8: root.result = "Sizden olur"; break;
                case 9: root.result = "Nikah tarihi seçin"; break;

            }
            
            Root ölcüm = new Root();
            ölcüm.firstname = root.firstname;
            ölcüm.secondname = root.secondname;
            ölcüm.result = root.result;
            ölcüm.percentagematch = amount;
            return View(ölcüm);





            //        string firstname = root.firstname;
            //        string secondname = root.secondname;
            //        var client = new HttpClient();
            //        var request = new HttpRequestMessage
            //        {
            //            Method = HttpMethod.Get,
            //            RequestUri = new Uri("https://the-love-calculator.p.rapidapi.com/love-calculator?fname="+firstname+"&sname="+secondname),
            //            Headers =
            //{
            //    { "X-RapidAPI-Key", "d317931d34msh05c39424a217125p134a3cjsn3214b19f3e1d" },
            //    { "X-RapidAPI-Host", "the-love-calculator.p.rapidapi.com" },
            //},
            //        };
            //        using (var response = await client.SendAsync(request))
            //        {
            //            response.EnsureSuccessStatusCode();
            //            var body = await response.Content.ReadAsStringAsync();
            //            Root ölcüm = JsonConvert.DeserializeObject<Root>(body);
            //            return View(ölcüm);
            //        }
        }


    }
}