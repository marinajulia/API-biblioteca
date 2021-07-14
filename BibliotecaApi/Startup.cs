using Biblioteca.Domain.Services.Autor;
using Biblioteca.Domain.Services.Categoria;
using Biblioteca.Domain.Services.CategoriaService;
using Biblioteca.Domain.Services.Editora;
using Biblioteca.Domain.Services.Livro;
using Biblioteca.Domain.Services.PerfilUsuario;
using Biblioteca.Domain.Services.StatusLivro;
using Biblioteca.Domain.Services.StatusLivro.Entities;
using Biblioteca.Infra.Data;
using Biblioteca.Infra.Repositories.Autor;
using Biblioteca.Infra.Repositories.Editora;
using Biblioteca.Infra.Repositories.Livro;
using Biblioteca.Infra.Repositories.PerfilUsuario;
using Biblioteca.Infra.Repositories.RepositoryCategoria;
using Biblioteca.Infra.Repositories.StatusUsuario;
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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<INotification, Notification>();

            RegisterRepositories(services);
            RegisterServices(services);
            
            services.AddControllers();
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<ApplicationContext, ApplicationContext>();

            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IEditoraRepository, EditoraRepository>();
            services.AddScoped<IPerfilUsuarioRepository, PerfilUsuarioRepository>();
            services.AddScoped<IStatusLivroRepository, StatusLivroRepository>();
            services.AddScoped<ILivroRepository, LivroRepository>();
        }

        private void RegisterServices (IServiceCollection services)
        {
            services.AddScoped<AutorService, AutorService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IEditoraService, EditoraService>();
            services.AddScoped<IPerfilUsuarioService, PerfilUsuarioService>();
            services.AddScoped<IStatusLivroService, StatusLivroService>();
            services.AddScoped<LivroService, LivroService>();
        }

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
