using AutoMapper;
using BookStore.Domain.Interface.Repository;
using BookStore.Domain.Interface.Service;
using BookStore.Domain.Model;
using BookStore.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace BookStore.Service
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _repository;
        private readonly IMapper _mapper;

        public GeneroService(IMapper mapper, IGeneroRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public GeneroViewModel Atualizar(GeneroViewModel genero)
        {
            var model = _mapper.Map<GeneroViewModel, Genero>(genero);
            model = _repository.Atualizar(model);
            _repository.SaveChanges();
            return _mapper.Map<Genero, GeneroViewModel>(model);
        }

        public GeneroViewModel BuscarPorId(int idGenero)
        {
            var genero = _repository.BuscarPorId(idGenero);
            return _mapper.Map<Genero, GeneroViewModel>(genero);
        }

        public IEnumerable<GeneroViewModel> BuscarTodos()
        {
            var generos = _repository.BuscarTodos();

            return _mapper.Map<IEnumerable<Genero>, IEnumerable<GeneroViewModel>>(generos);
        }

        public GeneroViewModel Deletar(int id)
        {
            var genero = _repository.BuscarPorId(id);

            _repository.Deletar(genero);
            _repository.SaveChanges();
            return _mapper.Map<Genero, GeneroViewModel>(genero);
        }

        public GeneroViewModel Novo(GeneroViewModel auto)
        {
            var model = _mapper.Map<GeneroViewModel, Genero>(auto);
            model = _repository.Novo(model);
            _repository.SaveChanges();
            return _mapper.Map<Genero, GeneroViewModel>(model);
        }
    }
}
