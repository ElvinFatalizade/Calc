using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServiceReference1;
using SOAP2JSON.Data;
using Microsoft.AspNetCore.Http;


namespace SOAP2JSON.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private CalculatorSoapClient _calculatorSoap = new CalculatorSoapClient(CalculatorSoapClient.EndpointConfiguration.CalculatorSoap12);
        private ValuesContext _context;
        private readonly ILogger<ValuesController> _lg;
        public ValuesController(ValuesContext valuesContext, ILogger<ValuesController> logger )
        {
            _context = valuesContext;
            _lg = logger;
        }
      

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] Num num)
        {
            _lg.LogInformation("add");
            int result = 0;

            try
            {
                await _context.AddLog(1, $"Required {JsonConvert.SerializeObject(num)}");
                result = await _calculatorSoap.AddAsync(num.Num1, num.Num2);
                _lg.LogInformation("succes", result);

                await _context.AddLog(1, $"Response {result} & {JsonConvert.SerializeObject(num)}");
                return Ok(result);
            }
            catch (Exception e)
            {
                await _context.AddLog(1, $"Required {JsonConvert.SerializeObject(num)}");
                await _context.AddLog(1, "Error");
                _lg.LogError("Error", e);
                throw;
            }
        }

        [HttpPost("subtract")]
        public async Task<IActionResult> Subtract([FromBody] Num num)
        {
            _lg.LogInformation("subtract");
            int result = 0;

            try
            {
                await _context.AddLog(1, $"Required {JsonConvert.SerializeObject(num)}");
                result = await _calculatorSoap.SubtractAsync(num.Num1, num.Num2);
                _lg.LogInformation("succes", result);

                await _context.AddLog(1, $"Response {result} & {JsonConvert.SerializeObject(num)}");
                return Ok(result);
            }
            catch (Exception e)
            {
                await _context.AddLog(1, $"Required {JsonConvert.SerializeObject(num)}");
                await _context.AddLog(1, "Error");
                _lg.LogError("Error", e);
                throw;
            }

        }
        [HttpPost("divide")]
        public async Task<IActionResult> Divide([FromBody] Num num)
        {
            _lg.LogInformation("divide");
            int result = 0;

            try
            {
                await _context.AddLog(1, $"Required {JsonConvert.SerializeObject(num)}");
                result = await _calculatorSoap.DivideAsync(num.Num1, num.Num2);
                _lg.LogInformation("succes", result);

                await _context.AddLog(1, $"Response {result} & {JsonConvert.SerializeObject(num)}");
                return Ok(result);
            }
            catch (Exception e)
            {
                await _context.AddLog(1, $"Required {JsonConvert.SerializeObject(num)}");
                await _context.AddLog(1, "Error");
                _lg.LogError("Error", e);
                throw;
            }

        }
        [HttpPost("multiply")]
        public async Task<IActionResult> MultiplyAsync([FromBody] Num num)
        {
            _lg.LogInformation("multiply");
            int result = 0;

            try
            {
                await _context.AddLog(1, $"Required {JsonConvert.SerializeObject(num)}");
                result = await _calculatorSoap.MultiplyAsync(num.Num1, num.Num2);
                _lg.LogInformation("succes", result);

                await _context.AddLog(1, $"Response {result} & {JsonConvert.SerializeObject(num)}");
                return Ok(result);
            }
            catch (Exception e)
            {
                await _context.AddLog(1, $"Required {JsonConvert.SerializeObject(num)}");
                await _context.AddLog(1, "Error");
                _lg.LogError("Error", e);
                throw;
            }
        }
    }
}
