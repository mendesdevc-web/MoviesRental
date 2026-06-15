using MoviesRental.Infrastructure;
using MoviesRental.Query.Infrastructure;
using MoviesRental.Query.Application;
using MoviesRental.WebApi.Cache;
using MovieRental.Application;
using MediatR;



namespace MoviesRental.WebApi.Setup
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddWriteApplication();
            services.AddWriteInfrastructure();
            services.AddQueryApplication();
            services.AddQueryInfrastructure();
            services.AddScoped<ICacheRepository, CacheRepository>();
            services.AddScoped<IMediator, Mediator>();
            return services;
        }
    }
}
