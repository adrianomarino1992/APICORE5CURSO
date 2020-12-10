using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCore5.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {       

        public CalculatorController()
        {
        }

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

    }
}
