using AutoMapper;
using BookStore.Domain.Interface.Repository;
using BookStore.Domain.Interface.Service;
using BookStore.Domain.Model;
using BookStore.Domain.ViewModel;
using BookStore.Infra.Context;
using BookStore.Infra.Repository;
using BookStore.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.WebApp.ExtensionMethods
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDI(this IServiceCollection services)
        {
            services.AddDbContext<BookStoreContext>();

            services.AddTransient<ILivroRepository, LivroRepository>();
            services.AddTransient<IAutorRepository, AutorRepository>();
            services.AddTransient<IEditoraRepository, EditoraRepository>();
            services.AddTransient<IGeneroRepository, GeneroRepository>();

            services.AddTransient<ILivroService, LivroService>();
            services.AddTransient<IAutorService, AutorService>();
            services.AddTransient<IEditoraService, EditoraService>();
            services.AddTransient<IGeneroService, GeneroService>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Livro, LivroViewModel>();
                c.CreateMap<Autor, AutorViewModel>().ReverseMap();
                c.CreateMap<Editora, EditoraViewModel>().ReverseMap();
                c.CreateMap<Genero, GeneroViewModel>().ReverseMap();
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
