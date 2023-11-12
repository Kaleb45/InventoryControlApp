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

    public static void AddPedido(Pedido pedido, DescPedido descPedido){
        using (Almacen db = new()){
            int? lastPedidoId = db.Pedidos.OrderByDescending(u => u.PedidoId).Select(u => u.PedidoId).FirstOrDefault();
            int pedidoID = lastPedidoId.HasValue ? lastPedidoId.Value + 1 : 1;
            pedido.PedidoId = pedidoID;
            descPedido.PedidoId = pedidoID;

            int? lastDesPedidoId = db.DescPedidos.OrderByDescending(u => u.DescPedidoId).Select(u => u.DescPedidoId).FirstOrDefault();
            int desPedidoID = lastDesPedidoId.HasValue ? lastDesPedidoId.Value + 1 : 1;
            descPedido.DescPedidoId = desPedidoID;
            WriteLine($"{pedido.PedidoId} | {descPedido.PedidoId}");
            
            var CheckStudent = db.Pedidos.FirstOrDefault(r => r.PedidoId == pedido.PedidoId);
            if (CheckStudent != null)
            {
                WriteLine("Datos de docentes ya existentes");
                return;
            }
            try
            {
                db.Pedidos.Add(pedido);
                db.DescPedidos.Add(descPedido);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                WriteLine($"{e}");
                throw;
            }
        }
    }

    public static void AddDescPedido(DescPedido descPedido){
        using (Almacen db = new Almacen()){
            Clear();
            db.DescPedidos.Add(descPedido);
            db.SaveChanges();
        } 
    }

    public static void NewMant(){
        Mantenimiento mantenimiento = GetDataOfMantenimiento();
        AddMant(mantenimiento);
    }

    public static Mantenimiento GetDataOfMantenimiento(){
        Mantenimiento mantenimiento = new Mantenimiento();
        Program.SectionTitle("Vamoa introducir un nuevo mantenimiento");
        do{
            WriteLine("Dame el nombre:");
            mantenimiento.Nombre = ReadLine();
        } while (mantenimiento.Nombre.Length > 50);
        do{
            WriteLine("Dame la descripcion:");
            mantenimiento.Descripcion = ReadLine();
        } while (mantenimiento.Descripcion.Length > 100);
        using (Almacen db = new()){
            int? lastMantId = db.Mantenimientos.OrderByDescending(u => u.MantenimientoId).Select(u => u.MantenimientoId).FirstOrDefault();
            int MantID = lastMantId.HasValue ? lastMantId.Value + 1 : 1;
            mantenimiento.MantenimientoId = MantID;
        }
        return mantenimiento;
    }

    public static void NewReportMant(){
        ReporteMantenimiento reporteMantenimiento = GetDataOfReportMant();
        AddReporteMant(reporteMantenimiento);
    }

    public static ReporteMantenimiento GetDataOfReportMant(){
        using(Almacen db = new()){
            ReporteMantenimiento reporteMantenimiento = new ReporteMantenimiento();
            Program.SectionTitle("Vamoa introducir un nuevo reporte de mantenimiento");
            string? input;
            do{
                WriteLine("Ingresa la fecha");
                input = ReadLine();
            }while(UI.DateValidation(input) == false);
            reporteMantenimiento.Fecha = DateTime.Parse(input);
            ReadMantenimientos();
            int mantenimientoId;
            Mantenimiento? mantenimiento;
            do{
                mantenimientoId = SearchId();
                mantenimiento = db.Mantenimientos!.FirstOrDefault(p => p.MantenimientoId == mantenimientoId);
                if((mantenimiento is null)){
                    WriteLine("No se encontro un mantenimiento para eliminar");
                }
                reporteMantenimiento.MantenimientoId = mantenimientoId;
            } while (mantenimiento == null && db.Mantenimientos != null);
            GeneralSearchCategory(4);
            reporteMantenimiento.MaterialId = UI.GetMaterialID(SearchId());
            return reporteMantenimiento;
        }
    }
}