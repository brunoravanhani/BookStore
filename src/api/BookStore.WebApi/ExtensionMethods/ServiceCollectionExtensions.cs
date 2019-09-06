using AutoMapper;
using BookStore.Domain.Interface.Repository;
using BookStore.Domain.Interface.Service;
using BookStore.Domain.Model;
using BookStore.Domain.ViewModel;
using BookStore.Infra.Repository;
using BookStore.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.WebApi.ExtensionMethods
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDI(this IServiceCollection services)
        {
            services.AddSingleton<ILivroRepository, LivroRepository>();

            services.AddTransient<ILivroService, LivroService>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Livro, LivroViewModel>();
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }   
    }
}
