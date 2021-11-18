using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using va.technical.challenge.domain.Constants;

namespace va.techinical.challenge.Ioc
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc(configuration.GetSection(Constantes.WebApiVersion).Value, new OpenApiInfo
                {
                    Title = configuration.GetSection(Constantes.WebApiDescription).Value,
                    Version = configuration.GetSection(Constantes.WebApiVersion).Value
                });
            });
        }

        public static void UseConfiguracoesDeSwagger(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{configuration.GetSection(Constantes.WebApiVersion).Value}/swagger.json",
                    configuration.GetSection(Constantes.WebApiDescription).Value);
            });
        }
    }
}
