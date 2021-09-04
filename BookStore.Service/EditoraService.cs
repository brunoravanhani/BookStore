using AutoMapper;
using BookStore.Domain.Interface.Repository;
using BookStore.Domain.Interface.Service;
using BookStore.Domain.Model;
using BookStore.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace BookStore.Service
{
    public class EditoraService : IEditoraService
    {
        private readonly IEditoraRepository _repository;
        private readonly IMapper _mapper;

        public EditoraService(IMapper mapper, IEditoraRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public EditoraViewModel Atualizar(EditoraViewModel editora)
        {
            var model = _mapper.Map<EditoraViewModel, Editora>(editora);
            model = _repository.Atualizar(model);
            _repository.SaveChanges();
            return _mapper.Map<Editora, EditoraViewModel>(model);
        }

        public EditoraViewModel BuscarPorId(int idEditora)
        {
            var editora = _repository.BuscarPorId(idEditora);
            return _mapper.Map<Editora, EditoraViewModel>(editora);
        }

        public IEnumerable<EditoraViewModel> BuscarTodos()
        {
            var editoras = _repository.BuscarTodos();

            return _mapper.Map<IEnumerable<Editora>, IEnumerable<EditoraViewModel>>(editoras);
        }

        public EditoraViewModel Deletar(int id)
        {
            var editora = _repository.BuscarPorId(id);

            _repository.Deletar(editora);
            _repository.SaveChanges();
            return _mapper.Map<Editora, EditoraViewModel>(editora);
        }

        public EditoraViewModel Novo(EditoraViewModel auto)
        {
            var model = _mapper.Map<EditoraViewModel, Editora>(auto);
            model = _repository.Novo(model);
            _repository.SaveChanges();
            return _mapper.Map<Editora, EditoraViewModel>(model);
        }
    }
}
