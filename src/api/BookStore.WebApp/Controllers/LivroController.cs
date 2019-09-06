using BookStore.Domain.Interface.Service;
using BookStore.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookStore.WebApp.Controllers
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
        public LivroViewModel Get(int id)
        {
            return _service.BuscarLivroPorId(id);
        }

        // POST: api/Livro
        [HttpPost]
        public void Post([FromBody] LivroViewModel livro)
        {
            _service.NovoLivro(livro);
        }

        // PUT: api/Livro/5
        [HttpPut]
        public void Put([FromBody] LivroViewModel livro)
        {
            _service.AtualizarLivro(livro);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
