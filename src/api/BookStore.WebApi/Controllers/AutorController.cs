using System;
using System.Collections.Generic;
using BookStore.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<AutorViewModel>> Get()
        {
            return new List<AutorViewModel> {
                new AutorViewModel {
                    IdAutor = 0,
                    NomeAutor = "Bruno Ravanhani"
                }
            };
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
