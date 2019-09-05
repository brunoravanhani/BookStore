using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.Interface.Service;
using BookStore.Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _service;
        public LivroController(ILivroService service)
        {
            _service = service;
        }

        // GET: api/Livro
        [HttpGet]
        public IEnumerable<LivroViewModel> Get()
        {
            return _service.BuscarTodosLivros();
        }

        // GET: api/Livro/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Livro
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Livro/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
