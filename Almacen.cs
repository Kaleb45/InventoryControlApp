using Microsoft.EntityFrameworkCore;
using Proyecto_Almacen.AutoGen;
using static System.Console;
namespace InventoryControl;

public class Almacen : DbContext
{

    public DbSet<Categoria> Categoria { get; set; }

    public DbSet<DescPedido> DescPedidos { get; set; }

    public DbSet<Docente> Docentes { get; set; }

    public DbSet<Estudiante> Estudiantes { get; set; }

    public DbSet<Grupo> Grupos { get; set; }

    public DbSet<Laboratorio> Laboratorios { get; set; }

    public DbSet<Mantenimiento> Mantenimientos { get; set; }

    public DbSet<Marca> Marcas { get; set; }

    public DbSet<Material> Materials { get; set; }

    public DbSet<Modelo> Modelos { get; set; }

    public DbSet<Pedido> Pedidos { get; set; }

    public DbSet<Plantel> Plantels { get; set; }

    public DbSet<Semestre> Semestres { get; set; }

    public DbSet<Tipo> Tipos { get; set; }

    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "Almacen.db");
        string connection = $"Filename={path}";
        ConsoleColor backgroundColor = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine($"Connection: {connection}");
        ForegroundColor = backgroundColor;
        optionsBuilder.UseSqlite(connection);
        //optionsBuilder.LogTo(WriteLine).EnableSensitiveDataLogging();

        // Using Lazy Loading
        optionsBuilder.UseLazyLoadingProxies();

    }

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

    }
}