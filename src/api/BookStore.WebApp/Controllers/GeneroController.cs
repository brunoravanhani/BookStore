using BookStore.Domain.Interface.Service;
using BookStore.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : Controller
    {
        private readonly IGeneroService _service;
        public GeneroController(IGeneroService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var resultado = _service.BuscarTodos();
                return Ok(resultado);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            try
            {
                var resultado = _service.BuscarPorId(id);
                return Ok(resultado);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] GeneroViewModel genero)
        {

            try
            {
                var resultado = _service.Novo(genero);
                return Ok(resultado);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] GeneroViewModel genero)
        {
            try
            {
                var resultado = _service.Atualizar(genero);
                return Ok(resultado);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
