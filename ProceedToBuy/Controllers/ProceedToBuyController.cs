using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProceedToBuy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProceedToBuyController : ControllerBase
    {
        readonly log4net.ILog _log4net;


        Uri baseAddress = new Uri("https://localhost:44321");
        HttpClient client;

        public ProceedToBuyController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            _log4net = log4net.LogManager.GetLogger(typeof(ProceedToBuyController));          
        }

        /*
         again getting the product detail to assure correct data of product ...client may temper the data......
        */
        [HttpGet("{Var}")]
        public IActionResult GetbyNameOrId(string Var)
        {
            _log4net.Info("ProceedToBuyController GetbyNameOrId Action Method is called ");

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "api/Product/" + Var).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return Ok(data);
            }
            return BadRequest();
        }

    }
}
