using BookStore.Domain.Interface.Repository;
using BookStore.Domain.Interface.Service;
using BookStore.Infra.Repository;
using BookStore.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.WebApi.ExtensionMethods
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDI(this IServiceCollection services)
        {
            services.AddTransient<ILivroRepository, LivroRepository>();

            services.AddTransient<ILivroService, LivroService>();
        }
    }
}
