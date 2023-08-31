using B3.DesafioCalculo.Business.Business;
using B3.DesafioCalculo.Business.Contracts;
using B3.DesafioCalculo.Shared.Behaviours;
using B3.DesafioCalculo.Shared.Settings;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace B3.DesafioCalculo.Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration) 
        {
            RegisterMediatR(services);

            RegisterValidators(services);

            RegisterSettings(services, configuration);

            RegisterBusiness(services);

            return services;
        }

        private static void RegisterBusiness(IServiceCollection services) 
        {
            services.AddScoped<ICalculadoraInvestimentosBusiness, CalculadoraInvestimentosBusiness>();
        }

        private static void RegisterMediatR(IServiceCollection services) 
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        }

        private static void RegisterSettings(IServiceCollection services, IConfiguration configuration) 
        {
            services.Configure<TaxasSettings>(configuration.GetSection("TaxasConfig"));
        }

        private static void RegisterValidators(IServiceCollection services)
            => services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic));
    }
}