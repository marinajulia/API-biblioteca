﻿// <auto-generated />
using Biblioteca.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Biblioteca.Infra.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Biblioteca.Domain.Services.Autor.Entities.AutorEntity", b =>
                {
                    b.Property<int>("AutorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeAutor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AutorId");

                    b.ToTable("Autor");
                });

            modelBuilder.Entity("Biblioteca.Domain.Services.Entidades.CategoriaEntity", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescriçãoCategoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCategoria")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Biblioteca.Domain.Services.Entidades.EditoraEntity", b =>
                {
                    b.Property<int>("EditoraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeEditora")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EditoraId");

                    b.ToTable("Editora");
                });

            modelBuilder.Entity("Biblioteca.Domain.Services.Entidades.LivroEntity", b =>
                {
                    b.Property<int>("LivroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descrição")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EditoraId")
                        .HasColumnType("int");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusLivroId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LivroId");

                    b.HasIndex("AutorId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("EditoraId");

                    b.HasIndex("StatusLivroId");

                    b.ToTable("Livro");
                });

            modelBuilder.Entity("Biblioteca.Domain.Services.Entidades.PerfilUsuarioEntity", b =>
                {
                    b.Property<int>("PerfilUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Perfil")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PerfilUsuarioId");

                    b.ToTable("PerfilUsuario");
                });

            modelBuilder.Entity("Biblioteca.Domain.Services.Entidades.StatusLivroEntity", b =>
                {
                    b.Property<int>("StatusLivroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusLivroId");

                    b.ToTable("StatusLivro");
                });

            modelBuilder.Entity("Biblioteca.Domain.Services.Entidades.StatusUsuarioEntity", b =>
                {
                    b.Property<int>("StatusUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusUsuarioId");

                    b.ToTable("StatusUsuario");
                });

            modelBuilder.Entity("Biblioteca.Domain.Services.Entidades.UsuarioEntity", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PerfilUsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusUsuarioId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId");

                    b.HasIndex("PerfilUsuarioId");

                    b.HasIndex("StatusUsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Biblioteca.Domain.Services.Entidades.UsuarioLivrosEntity", b =>
                {
                    b.Property<int>("UsuarioLivrosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LivroId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioLivrosId");

                    b.HasIndex("LivroId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioLivros");
                });

            modelBuilder.Entity("Biblioteca.Domain.Services.Entidades.LivroEntity", b =>
                {
                    b.HasOne("Biblioteca.Domain.Services.Autor.Entities.AutorEntity", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca.Domain.Services.Entidades.CategoriaEntity", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca.Domain.Services.Entidades.EditoraEntity", "Editora")
                        .WithMany()
                        .HasForeignKey("EditoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca.Domain.Services.Entidades.StatusLivroEntity", "StatusLivro")
                        .WithMany()
                        .HasForeignKey("StatusLivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Categoria");

                    b.Navigation("Editora");

                    b.Navigation("StatusLivro");
                });

            modelBuilder.Entity("Biblioteca.Domain.Services.Entidades.UsuarioEntity", b =>
                {
                    b.HasOne("Biblioteca.Domain.Services.Entidades.PerfilUsuarioEntity", "PerfilUsuario")
                        .WithMany()
                        .HasForeignKey("PerfilUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca.Domain.Services.Entidades.StatusUsuarioEntity", "StatusUsuario")
                        .WithMany()
                        .HasForeignKey("StatusUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PerfilUsuario");

                    b.Navigation("StatusUsuario");
                });

            modelBuilder.Entity("Biblioteca.Domain.Services.Entidades.UsuarioLivrosEntity", b =>
                {
                    b.HasOne("Biblioteca.Domain.Services.Entidades.LivroEntity", "Livro")
                        .WithMany()
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca.Domain.Services.Entidades.UsuarioEntity", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livro");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
