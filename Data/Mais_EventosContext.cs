using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Exercicio02.Models;

#nullable disable

namespace Exercicio02.Data
{
    public partial class Mais_EventosContext : DbContext
    {
        public Mais_EventosContext()
        {
        }

        public Mais_EventosContext(DbContextOptions<Mais_EventosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RlUsuarioEvento> RlUsuarioEventos { get; set; }
        public virtual DbSet<TbCategoria> TbCategorias { get; set; }
        public virtual DbSet<TbEvento> TbEventos { get; set; }
        public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = .\\SQLEXPRESS; Initial Catalog = Mais_Eventos; User Id=sa; Password=Admin1234;")
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<RlUsuarioEvento>(entity =>
            {
                entity.ToTable("RL_USUARIO_EVENTO");

                entity.HasOne(d => d.Evento)
                    .WithMany(p => p.RlUsuarioEventos)
                    .HasForeignKey(d => d.EventoId)
                    .HasConstraintName("FK__RL_USUARI__Event__2A4B4B5E");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.RlUsuarioEventos)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__RL_USUARI__Usuar__2B3F6F97");
            });

            modelBuilder.Entity<TbCategoria>(entity =>
            {
                entity.ToTable("TB_CATEGORIAS");
            });

            modelBuilder.Entity<TbEvento>(entity =>
            {
                entity.ToTable("TB_EVENTOS");

                entity.Property(e => e.DataHora).HasColumnType("datetime");

                entity.Property(e => e.Preco).HasColumnType("decimal(6, 2)");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.TbEventos)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("FK__TB_EVENTO__Categ__2C3393D0");
            });

            modelBuilder.Entity<TbUsuario>(entity =>
            {
                entity.ToTable("TB_USUARIOS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
