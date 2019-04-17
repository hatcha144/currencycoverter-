using CurrencyAPI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExchangerateLab.Net;


namespace CurrencyAPI.Controllers
{
    public class HomeController : Controller
    {
       

        //[HttpPost]
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Results(string currency)

        {
            string final = APIstring(currency);
            HttpWebRequest request = WebRequest.CreateHttp(final);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string data = rd.ReadToEnd();
            JObject currencyJson = JObject.Parse(data);

            List<JToken> singlePost = currencyJson["rates"].ToList();

            List<Currency> current = new List<Currency>();

            for (int i = 0; i < singlePost.Count; i++)
            {
                Currency c = new Currency();
                c.Rates = (decimal)singlePost[i];
                current.Add(c);
            }
            Session["CurrencyList"] = current;
            ViewBag.CurrencyList = current;
            return View();
        }
        
        public static string APIstring(string currency)
        {
            string prefix = "https://api.exchangeratesapi.io/latest?base=";
            string final = "";
            final = (prefix + currency);
            return final;
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}