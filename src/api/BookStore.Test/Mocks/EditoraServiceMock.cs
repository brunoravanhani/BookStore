using BookStore.Domain.Interface.Service;
using BookStore.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Test.Mocks
{
    public class EditoraServiceMock : IEditoraService
    {

        private List<EditoraViewModel> editoras = new List<EditoraViewModel>
        {
            new EditoraViewModel
            {
                IdEditora = 1,
                Nome = "Editora Globo"
            }
        };

        public EditoraViewModel Atualizar(EditoraViewModel editora)
        {
            var index = editoras.FindIndex(e => e.IdEditora == editora.IdEditora);
            editoras[index] = editora;
            return editora;
        }

        public EditoraViewModel BuscarPorId(int idEditora)
        {
            var model = editoras.FirstOrDefault(e => e.IdEditora == idEditora);
            return model;
        }

        public IEnumerable<EditoraViewModel> BuscarTodos()
        {
            return editoras;
        }

        public EditoraViewModel Deletar(int id)
        {
            var model = editoras.FirstOrDefault(e => e.IdEditora == id);
            editoras.Remove(model);
            return model;
        }

        public EditoraViewModel Novo(EditoraViewModel editora)
        {
            editoras.Add(editora);
            return editora;
        }
    }
}
