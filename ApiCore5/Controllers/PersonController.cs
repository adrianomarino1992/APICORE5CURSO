using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCore5.Business.Implementations;
using ApiCore5.Business;
using ApiCore5.Model;

namespace ApiCore5.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/[action]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {     


        private readonly ILogger<PersonController> _logger;

        private IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_personBusiness.Get());
        }        

        [HttpGet("/persons/byid/{id}")]
        public IActionResult Search(int id)
        {
            return Ok(_personBusiness.Get(id));
        }

        [HttpPost("/persons/create")]
        public IActionResult Create([FromBody] Person person)
        {
            return Ok(_personBusiness.Create(person));
        }

        [HttpPut("/persons/update")]
        public IActionResult Update([FromBody] Person person)
        {
            return Ok(_personBusiness.Update(person));
        }


        [HttpDelete("/persons/delete/{id}")]
        public IActionResult Delete(int id)
        {
            _personBusiness.Delete(id);  
            
            return NoContent();
        }

    }

}
