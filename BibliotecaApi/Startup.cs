using Biblioteca.Domain.Services.Categoria;
using Biblioteca.Domain.Services.CategoriaService;
using Biblioteca.Infra.Data;
using Biblioteca.Infra.Repositories.RepositoryCategoria;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SharedKernel.Domain.Notification;

namespace BibliotecaApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<INotification, Notification>();


            //Repositorios
            services.AddScoped<ApplicationContext, ApplicationContext>();
            //services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            //Services
            services.AddScoped<ICategoriaService, CategoriaService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
