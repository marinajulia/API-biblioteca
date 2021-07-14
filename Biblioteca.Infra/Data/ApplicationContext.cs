using Biblioteca.Domain.Services.Autor.Entities;
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

        public DbSet<AutorEntity> Autor { get; set; }
        public DbSet<CategoriaEntity> Categoria { get; set; }
        public DbSet<EditoraEntity> Editora { get; set; }
        public DbSet<LivroEntity> Livro { get; set; }
        public DbSet<PerfilUsuarioEntity> PerfilUsuario { get; set; }
        public DbSet<StatusLivroEntity> StatusLivro { get; set; }
        public DbSet<StatusUsuarioEntity> StatusUsuario { get; set; }
        public DbSet<UsuarioEntity> Usuario { get; set; }
        public DbSet<UsuarioLivrosEntity> UsuarioLivros { get; set; }

    }
}
