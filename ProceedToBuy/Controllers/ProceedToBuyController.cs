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
       
        Uri baseAddress = new Uri("http://40.76.132.82");
        HttpClient client;

        public ProceedToBuyController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;        
        }

        /*
         again getting the product detail to assure correct data of product ...client may temper the data......
        */
        [HttpGet("{Var}")]
        public IActionResult GetbyNameOrId(string Var)
        {
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
