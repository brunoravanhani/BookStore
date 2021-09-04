using AutoMapper;
using BookStore.Domain.Interface.Repository;
using BookStore.Domain.Interface.Service;
using BookStore.Domain.Model;
using BookStore.Domain.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Service
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _repository;
        private readonly IMapper _mapper;

        public AutorService(IMapper mapper, IAutorRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public AutorViewModel Atualizar(AutorViewModel autor)
        {
            var model = _mapper.Map<AutorViewModel, Autor>(autor);
            model = _repository.Atualizar(model);
            _repository.SaveChanges();
            return _mapper.Map<Autor, AutorViewModel>(model);
        }

        public AutorViewModel BuscarPorId(int idAutor)
        {
            var autor = _repository.BuscarPorId(idAutor);
            return _mapper.Map<Autor, AutorViewModel>(autor);
        }

        public IEnumerable<AutorViewModel> BuscarTodos()
        {
            var autores = _repository.BuscarTodos().ToList();

            return _mapper.Map<IEnumerable<Autor>, IEnumerable<AutorViewModel>>(autores);
        }

        public AutorViewModel Deletar(int id)
        {
            var autor = _repository.BuscarPorId(id);

            _repository.Deletar(autor);
            _repository.SaveChanges();
            return _mapper.Map<Autor, AutorViewModel>(autor);
        }

        public AutorViewModel Novo(AutorViewModel auto)
        {
            var model = _mapper.Map<AutorViewModel, Autor>(auto);
            model = _repository.Novo(model);
            _repository.SaveChanges();
            return _mapper.Map<Autor, AutorViewModel>(model);
        }
    }
}
