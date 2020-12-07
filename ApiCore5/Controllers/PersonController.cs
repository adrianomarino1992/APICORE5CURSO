using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCore5.Services.Implementations;
using ApiCore5.Services;
using ApiCore5.Model;

namespace ApiCore5.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PersonController : ControllerBase
    {


        private readonly ILogger<PersonController> _logger;

        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_personService.Get());
        }

        [HttpGet("/persons/byid/{id}")]
        public IActionResult Search(int id)
        {
            return Ok(_personService.Get(id));
        }

        [HttpPost("/persons/create")]
        public IActionResult Create([FromBody] Person person)
        {
            return Ok(_personService.Create(person));
        }

        [HttpPut("/persons/update")]
        public IActionResult Update([FromBody] Person person)
        {
            return Ok(_personService.Create(person));
        }


        [HttpDelete("/persons/delete/{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return NoContent();
        }


        /*
        [HttpGet("/sum/{firtsNumber}/{secondNumber}")]
        public IActionResult Get(string firtsNumber, string secondNumber)
        {
            if (IsNumber(firtsNumber) && IsNumber(secondNumber))
            {
                return Ok(NumberToDecimal(firtsNumber) + NumberToDecimal(secondNumber));
            }
            return BadRequest("Error on parameters");
        }

        private decimal NumberToDecimal(string firstNumber)
        {
            decimal number;
            if (decimal.TryParse(firstNumber, out number))
            {
                return number;
            }
            return 0;
        }

        private bool IsNumber(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;

        }

        [HttpGet("/subtraction/{firtsNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firtsNumber, string secondNumber)
        {
            if (IsNumber(firtsNumber) && IsNumber(secondNumber))
            {
                return Ok(NumberToDecimal(firtsNumber) - NumberToDecimal(secondNumber));
            }
            return BadRequest("Error on parameters");

        }

        [HttpGet("/multiplication/{firtsNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firtsNumber, string secondNumber)
        {
            if (IsNumber(firtsNumber) && IsNumber(secondNumber))
            {
                return Ok(NumberToDecimal(firtsNumber) * NumberToDecimal(secondNumber));
            }
            return BadRequest("Error on parameters");

        }


        [HttpGet("/split/{firtsNumber}/{secondNumber}")]
        public IActionResult Split(string firtsNumber, string secondNumber)
        {
            if (IsNumber(firtsNumber) && IsNumber(secondNumber))
            {
                return Ok(NumberToDecimal(firtsNumber) / NumberToDecimal(secondNumber));
            }
            return BadRequest("Error on parameters");

        }

        */

    }

}
