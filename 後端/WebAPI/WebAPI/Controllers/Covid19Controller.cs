using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using WebAPI.Models;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    public class Covid19Controller : Controller
    {
        public async Task<ActionResult> Index()
        {
            string url = "https://covid-19.nchc.org.tw/api/covid19?CK=covid-19@nchc.org.tw&querydata=4051&limited=TWN";

            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            var resp = await client.GetStringAsync(url);

            var collection = JsonConvert.DeserializeObject<IEnumerable<Covid_19>>(resp);//反序列化

            return View(collection);
        }
    }
}