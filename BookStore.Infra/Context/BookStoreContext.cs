using BookStore.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookStore.Infra.Context
{
    public partial class BookStoreContext : DbContext
    {
        public BookStoreContext()
        {
        }

        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<Editora> Editora { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Livro> Livro { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 25));
            optionsBuilder.UseMySql(serverVersion, options => options.MigrationsAssembly("BookStore.Api"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.IdAutor);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Editora>(entity =>
            {
                entity.HasKey(e => e.IdEditora);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero);

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Livro>(entity =>
            {
                entity.HasKey(e => e.IdLivro);

                entity.Property(e => e.DataPublicacao).HasColumnType("datetime");

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.ImagemCapa).IsUnicode(false);

                entity.Property(e => e.Link)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Sinopse).IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany(p => p.Livro)
                    .HasForeignKey(d => d.IdAutor)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdEditoraNavigation)
                    .WithMany(p => p.Livro)
                    .HasForeignKey(d => d.IdEditora)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Livro)
                    .HasForeignKey(d => d.IdGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
