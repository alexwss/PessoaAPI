using System.Net;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PessoaAPI.utils;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace PessoaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IHttpContextAccessor _accessor;

        public ValuesController(IHttpContextAccessor accessor){
            _accessor = accessor;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            StringValues xItau = "";

            _accessor.HttpContext.Request.Path.ToString();

            _accessor.HttpContext.Request.Headers.TryGetValue("x-itau-correlationID", out xItau);

            Console.WriteLine("/----------------------LOG--------------------------/");
            Console.WriteLine("IP: " + _accessor.HttpContext.Connection.RemoteIpAddress.ToString());
            Console.WriteLine("HOSTNAME: " + Dns.GetHostName().ToString());
            Console.WriteLine($"x-itau-correlationID: {xItau.ToString()}");
            Console.WriteLine("/----------------------LOG--------------------------/");

            if (SingletonSample.Instance.isWorkInProgress()){
                return "Em execucao";
            }

            new Thread(new ThreadStart(SingletonSample.Instance.processing)).Start();

            return "Processo iniciado..." ;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
