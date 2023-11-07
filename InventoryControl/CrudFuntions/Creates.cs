using System;
using AlmacenDataContext;
using AlmacenSQLiteEntities;
public static partial class CrudFuntions{
    public static void AddStudent(Estudiante estudiante, Usuario usuario){
        using (Almacen db = new()){
            var CheckStudent = db.Estudiantes.FirstOrDefault(r => r.EstudianteId == estudiante.EstudianteId || r.Correo == estudiante.Correo);
            if (CheckStudent != null)
            {
                WriteLine("Datos de usuario ya existentes");
                return;
            }
            int? lastUserId = db.Usuarios.OrderByDescending(u => u.UsuarioId).Select(u => u.UsuarioId).FirstOrDefault();
            int UserID = lastUserId.HasValue ? lastUserId.Value + 1 : 1;
            usuario.UsuarioId = UserID;
            estudiante.UsuarioId = UserID;
            Clear();
            db.Estudiantes.Add(estudiante);
            db.Usuarios.Add(usuario);
            db.SaveChanges();
        }
    }

    public static void AddTeacher(Docente docente, Usuario usuario){
        using (Almacen db = new()){
            var CheckStudent = db.Docentes.FirstOrDefault(r => r.DocenteId == docente.DocenteId || r.Correo == docente.Correo);
            if (CheckStudent != null)
            {
                WriteLine("Datos de docentes ya existentes");
                return;
            }
            int? lastUserId = db.Usuarios.OrderByDescending(u => u.UsuarioId).Select(u => u.UsuarioId).FirstOrDefault();
            int UserID = lastUserId.HasValue ? lastUserId.Value + 1 : 1;
            usuario.UsuarioId = UserID;
            docente.UsuarioId = UserID;
            Clear();
            db.Docentes.Add(docente);
            db.Usuarios.Add(usuario);
            db.SaveChanges();
        }
    }

    public static void AddWarehouseManager(Almacenista almacenista, Usuario usuario){
        using (Almacen db = new()){
            var CheckStudent = db.Almacenistas.FirstOrDefault(r => r.AlmacenistaId == almacenista.AlmacenistaId || r.Correo == almacenista.Correo);
            if (CheckStudent != null)
            {
                WriteLine("Datos de docentes ya existentes");
                return;
            }
            int? lastUserId = db.Usuarios.OrderByDescending(u => u.UsuarioId).Select(u => u.UsuarioId).FirstOrDefault();
            int UserID = lastUserId.HasValue ? lastUserId.Value + 1 : 1;
            usuario.UsuarioId = UserID;
            almacenista.UsuarioId = UserID;
            Clear();
            db.Almacenistas.Add(almacenista);
            db.Usuarios.Add(usuario);
            db.SaveChanges();
        }
    }

    public static void AddMarca(Marca marca){
        using (Almacen db = new()){
            Clear();
            db.Marcas.Add(marca);
            db.SaveChanges();
        }
    }

    public static void AddModelo(Modelo modelo){
        using (Almacen db = new()){
            Clear();
            db.Modelos.Add(modelo);
            db.SaveChanges();
        }
    }

    public static void AddCategoria(Categoria categoria){
        using (Almacen db = new()){
            Clear();
            db.Categorias.Add(categoria);
            db.SaveChanges();
        }
    }

    public static void AddLab(Laboratorio laboratorio){
        using (Almacen db = new()){
            Clear();
            db.Laboratorios.Add(laboratorio);
            db.SaveChanges();
        }
    }

    public static void AddMant(Mantenimiento mantenimiento){
        using (Almacen db = new()){
            Clear();
            db.Mantenimientos.Add(mantenimiento);
            db.SaveChanges();
        }
    }

    public static void AddMaterial(Material material){
        using (Almacen db = new Almacen()){
            Clear();
            db.Materiales.Add(material);
            db.SaveChanges();
        }
    }

    public static void AddGroup(Grupo grupo){
        using (Almacen db = new Almacen()){
            Clear();
            db.Grupos.Add(grupo);
            db.SaveChanges();
        } 
    }

    public static void AddReporteMant(ReporteMantenimiento Reporte){
        using (Almacen db = new Almacen()){
            Clear();
            db.ReporteMantenimientos.Add(Reporte);
            db.SaveChanges();
        } 
    }

    public static void AddPedido(Pedido pedido){
        using (Almacen db = new Almacen()){
            Clear();
            db.Pedidos.Add(pedido);
            db.SaveChanges();
        } 
    }

    public static void AddDescPedido(DescPedido descPedido){
        using (Almacen db = new Almacen()){
            Clear();
            db.DescPedidos.Add(descPedido);
            db.SaveChanges();
        } 
    }
}