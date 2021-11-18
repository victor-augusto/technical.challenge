using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using va.technical.challenge.api.Filtros;

namespace va.techinical.challenge.Ioc
{
    public static class ConfiguracaoDaApi
    {
        public static void AddCongiguracaoDaApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerConfiguration(configuration);
            services.AddControllers(configuration =>
            {
                configuration.Filters.Add(typeof(ProxyExceptionFilter));
            })
            .AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            });
        }

    }
}
