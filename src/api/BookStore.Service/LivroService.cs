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

        public LivroViewModel AtualizarLivro(LivroViewModel livro)
        {
            var model = _mapper.Map<LivroViewModel, Livro>(livro);
            model = _repository.Atualizar(model);
            return _mapper.Map<Livro, LivroViewModel>(model);
        }

        public LivroViewModel BuscarLivroPorId(int idLivro)
        {
            var livro = _repository.BuscarPorId(idLivro);
            return _mapper.Map<Livro, LivroViewModel>(livro);
        }

        public IEnumerable<LivroViewModel> BuscarTodosLivros()
        {
            var livros = _repository.BuscarTodos();

            return _mapper.Map<IEnumerable<Livro>,IEnumerable<LivroViewModel>>(livros);
        }

        public LivroViewModel DeletarLivro(LivroViewModel livro)
        {
            var model = _mapper.Map<LivroViewModel, Livro>(livro);

            _repository.Deletar(model);
            return livro;
        }

        public LivroViewModel NovoLivro(LivroViewModel livro)
        {
            var model = _mapper.Map<LivroViewModel, Livro>(livro);
            model = _repository.Novo(model);
            return _mapper.Map<Livro, LivroViewModel>(model);
        }
    }
}
