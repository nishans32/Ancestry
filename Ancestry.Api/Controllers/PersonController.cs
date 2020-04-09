using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ancestry.Common.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ancestry.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        //Todo - Add a global exception handler
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personService.Get(id);
            return person != null
                ? (IActionResult) Ok(person)
                : NotFound();
        }

        [HttpGet]
        [Route("search/{name}")]
        public IActionResult Search(string name, string gender, int index, int count)
        {
            var result = _personService.Search(name, gender, index, count);
            return result.TotalCount != 0
                ? (IActionResult) Ok(result)
                : NotFound();
        }
    }


}