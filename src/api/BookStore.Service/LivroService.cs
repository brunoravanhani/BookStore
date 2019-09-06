using AutoMapper;
using BookStore.Domain.Interface.Repository;
using BookStore.Domain.Interface.Service;
using BookStore.Domain.Model;
using BookStore.Domain.ViewModel;
using System.Collections.Generic;

namespace BookStore.Service
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _repository;
        private readonly IMapper _mapper;

        public LivroService(IMapper mapper, ILivroRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public LivroViewModel Atualizar(LivroViewModel livro)
        {
            var model = _mapper.Map<LivroViewModel, Livro>(livro);
            model = _repository.Atualizar(model);
            _repository.SaveChanges();
            return _mapper.Map<Livro, LivroViewModel>(model);
        }

        public LivroViewModel BuscarPorId(int idLivro)
        {
            var livro = _repository.BuscarPorId(idLivro);
            return _mapper.Map<Livro, LivroViewModel>(livro);
        }

        public IEnumerable<LivroViewModel> BuscarTodos()
        {
            var livros = _repository.BuscarTodos();

            return _mapper.Map<IEnumerable<Livro>,IEnumerable<LivroViewModel>>(livros);
        }

        public LivroViewModel Deletar(int id)
        {
            var model = _repository.BuscarPorId(id);

            _repository.Deletar(model);
            _repository.SaveChanges();
            return _mapper.Map<Livro, LivroViewModel>(model);
        }

        public LivroViewModel Novo(LivroViewModel livro)
        {
            var model = _mapper.Map<LivroViewModel, Livro>(livro);
            model = _repository.Novo(model);
            _repository.SaveChanges();
            return _mapper.Map<Livro, LivroViewModel>(model);
        }
    }
}
