using Biblioteca.Domain.Common.Token;
using Biblioteca.Domain.Services;
using Biblioteca.Domain.Services.Autor;
using Biblioteca.Domain.Services.Categoria;
using Biblioteca.Domain.Services.CategoriaService;
using Biblioteca.Domain.Services.Editora;
using Biblioteca.Domain.Services.Livro;
using Biblioteca.Domain.Services.PerfilUsuario;
using Biblioteca.Domain.Services.StatusLivro;
using Biblioteca.Domain.Services.StatusLivro.Entities;
using Biblioteca.Domain.Services.StatusUsuario;
using Biblioteca.Domain.Services.Usuario;
using Biblioteca.Domain.Services.UsuarioLivros;
using Biblioteca.Infra.Data;
using Biblioteca.Infra.Repositories;
using Biblioteca.Infra.Repositories.Autor;
using Biblioteca.Infra.Repositories.Editora;
using Biblioteca.Infra.Repositories.Livro;
using Biblioteca.Infra.Repositories.PerfilUsuario;
using Biblioteca.Infra.Repositories.RepositoryCategoria;
using Biblioteca.Infra.Repositories.StatusUsuario;
using Biblioteca.Infra.Repositories.Usuario;
using Biblioteca.Infra.Repositories.UsuarioLivros;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SharedKernel.Domain.Notification;
using System.Text;

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

            services.AddCors();
            services.AddControllers();

            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Biblioteca", Version = "v1" });
            });

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
            services.AddScoped<IStatusUsuarioRepository, StatusUsuarioRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioLivrosRepository, UsuarioLivrosRepository>();
        }

        private void RegisterServices (IServiceCollection services)
        {
            services.AddScoped<IAutorService, AutorService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IEditoraService, EditoraService>();
            services.AddScoped<IPerfilUsuarioService, PerfilUsuarioService>();
            services.AddScoped<IStatusLivroService, StatusLivroService>();
            services.AddScoped<ILivroService, LivroService>();
            services.AddScoped<IStatusUsuarioService, StatusUsuarioService>();
             //services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioLivrosService, UsuarioLivrosService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Biblioteca v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
