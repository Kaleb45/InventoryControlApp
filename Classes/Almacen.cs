using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Almacen.AutoGen;

public partial class Almacen : DbContext
{
    public Almacen()
    {
    }

    public Almacen(DbContextOptions<Almacen> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<DescPedido> DescPedidos { get; set; }

    public virtual DbSet<Docente> Docentes { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<Laboratorio> Laboratorios { get; set; }

    public virtual DbSet<Mantenimiento> Mantenimientos { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Plantel> Plantels { get; set; }

    public virtual DbSet<Semestre> Semestres { get; set; }

    public virtual DbSet<Tipo> Tipos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Filename=Almacen.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.Property(e => e.CategoriaId).ValueGeneratedNever();
        });

        modelBuilder.Entity<DescPedido>(entity =>
        {
            entity.Property(e => e.DescPedidoId).ValueGeneratedNever();

            entity.HasOne(d => d.Material).WithMany(p => p.DescPedidos).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Pedido).WithMany(p => p.DescPedidos).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Docente>(entity =>
        {
            entity.Property(e => e.DocenteId).ValueGeneratedNever();

            entity.HasOne(d => d.Plantel).WithMany(p => p.Docentes).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Docentes).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.Property(e => e.EstudianteId).ValueGeneratedNever();

            entity.HasOne(d => d.Grupo).WithMany(p => p.Estudiantes).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Plantel).WithMany(p => p.Estudiantes).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Semestre).WithMany(p => p.Estudiantes).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Estudiantes).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.Property(e => e.GrupoId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Laboratorio>(entity =>
        {
            entity.Property(e => e.LaboratorioId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Mantenimiento>(entity =>
        {
            entity.Property(e => e.MantenimientoId).ValueGeneratedNever();

            entity.HasOne(d => d.Material).WithMany(p => p.Mantenimientos).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Tipo).WithMany(p => p.Mantenimientos).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.Property(e => e.MarcaId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.Property(e => e.MaterialId).ValueGeneratedNever();

            entity.HasOne(d => d.Categoria).WithMany(p => p.Materials).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Marca).WithMany(p => p.Materials).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Modelo).WithMany(p => p.Materials).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.Property(e => e.ModeloId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.Property(e => e.PedidoId).ValueGeneratedNever();

            entity.HasOne(d => d.Docente).WithMany(p => p.Pedidos).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Estudiante).WithMany(p => p.Pedidos).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Laboratorio).WithMany(p => p.Pedidos).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Plantel>(entity =>
        {
            entity.Property(e => e.PlantelId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Semestre>(entity =>
        {
            entity.Property(e => e.SemestreId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Tipo>(entity =>
        {
            entity.Property(e => e.TipoId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.UsuarioId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
