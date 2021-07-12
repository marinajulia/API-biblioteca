using Biblioteca.Domain.Services.Categoria;
using Biblioteca.Domain.Services.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infra.Data
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-TUN7NB2\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True");
            
        }

        public DbSet<Domain.Services.Categoria.Categoria> Autores { get; set; }
        public DbSet<Domain.Services.Entidades.CategoriaEntity> Categoria { get; set; }
        public DbSet<Editora> Editora { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<PerfilUsuario> PerfilUsuario { get; set; }
        public DbSet<StatusLivro> StatusLivro { get; set; }
        public DbSet<StatusUsuario> StatusUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioLivros> UsuarioLivros { get; set; }

    }
}
