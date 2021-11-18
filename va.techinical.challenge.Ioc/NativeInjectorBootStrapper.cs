using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using va.techinical.challenge.Ioc.Mapeamentos;
using va.technical.challenge.domain.Dtos.Divisor;
using va.technical.challenge.domain.Interfaces;
using va.technical.challenge.services;


namespace va.techinical.challenge.Ioc
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperConfig));
            services.AddScoped<IMapper>(sm => new Mapper(sm.GetRequiredService<IConfigurationProvider>(), sm.GetService));
            services.AddScoped<IDivisorService, DivisorService>();
            services.AddScoped<IDivisorPrimoService, DivisorPrimoService>();
            services.AddTransient<IValidator<DivisorRequest>, DivisorRequestValidator>();
        }
    }
}
