using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class CovidAPIController : ApiController
    {
        public async Task<IEnumerable<Covid_19>> Get()
        {
            string url = "https://covid-19.nchc.org.tw/api/covid19?CK=covid-19@nchc.org.tw&querydata=4051&limited=TWN";

            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            var resp = await client.GetStringAsync(url);

            var collection = JsonConvert.DeserializeObject<IEnumerable<Covid_19>>(resp);//反序列化

            return collection;
        }
    }
}
