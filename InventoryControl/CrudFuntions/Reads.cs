using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using AlmacenDataContext;
using AlmacenSQLiteEntities;
using System.Linq;
public static partial class CrudFuntions{

    public static int SearchId(){
        Program.SectionTitle("Selecciona alguno se los anteriores");
        string? input;
        int Id;
        do{
            WriteLine("Ingresa el ID: ");
            input = ReadLine();
        } while (!int.TryParse(input, out Id));
        return Id;
    }

    public static void GeneralSearchCategory(int typeOfUser){
        using(Almacen db = new()){
            IQueryable<Categoria> result;
            string? input = "";
            WriteLine($"Por favor ingrese el elemento a buscar: ");
            input = ReadLine();
            input = input.ToUpper();
            result = db.Categorias.Where(r => r.Nombre.Contains(input));
            if(result is null || !result.Any())
            {
                WriteLine("No se encontro ningun elemento con el nombre ingresado :");
                GeneralSearchCategory(typeOfUser);
            }
            ReadQueryCategorias(result);
        }
    }

    public static void GeneralSearchTeacher(){
        using(Almacen db = new()){
            IQueryable<Docente> result;
            string? input = "";
            WriteLine($"Por favor ingrese el maestro a buscar: ");
            input = ReadLine();
            input = input.ToUpper();
            result = db.Docentes.Where(r => r.Nombre.Contains(input));
            if(result is null || !result.Any())
            {
                WriteLine("No se encontro ningun profesor con el nombre ingresado :");
                GeneralSearchTeacher();
            }
            ReadQueryDocentes(result);
        }
    }

    public static void ListMaterialsWithHighlight(int[]? materialIdHighlight = null){
        using(Almacen db = new()){
            if(db.Materiales is null || (!db.Materiales.Any())){
                Program.Fail("No hay materiales registrados");
                return;
            }
            WriteLine("{0,-3} | {1,-35} | {2,8} | {3,5} | {4}","Id","Descripcion","Año de Entrada","Modelo","Marca");
            foreach(var material in db.Materiales!){
                ConsoleColor backgroundColor = ForegroundColor;
                if((materialIdHighlight is not null) && materialIdHighlight.Contains(material.MaterialId)){
                    ForegroundColor = ConsoleColor.Green;
                }
                WriteLine($"{material.MaterialId,-3} | {material.Descripcion,-35} | {material.YearEntrada,-14} | {material.Modelo.Nombre,6} | {material.Marca.Nombre}");
                ForegroundColor = backgroundColor;
            }
            WriteLine();
        }
    }
    
    public static void ListOrdersWithHighlight(int[]? ordersIdHighlight = null){
        using(Almacen db = new()){
            if(db.Pedidos is null || (!db.Pedidos.Any())){
                Program.Fail("No hay pedidos registrados");
                return;
            }
            WriteLine("{0,-3} | {1,-35} | {2,-8} | {3,-25} | {4,-25} | {5,-10} | {6,-10} | {7}","Id","Fecha","Laboratorio","Hora de Entrega","Hora de Devolucion","Estudiante","Docente","Aprovado");
            foreach(var pedidos in db.Pedidos!){
                ConsoleColor backgroundColor = ForegroundColor;
                if((ordersIdHighlight is not null) && ordersIdHighlight.Contains(pedidos.PedidoId)){
                    ForegroundColor = ConsoleColor.Green;
                }
                WriteLine($"{pedidos.PedidoId,-3} | {pedidos.Fecha,-35} | {pedidos.Laboratorio.Nombre,-11} | {pedidos.HoraEntrega,-6} | {pedidos.HoraDevolucion,-5} | {pedidos.Estudiante.Nombre,-10} | {pedidos.Docente.Nombre,-10} | {(pedidos.Estado ? "SI" : "NO")}");
                ForegroundColor = backgroundColor;
            }
            WriteLine();
        }
    }
    
    public static void ListTeachers(int[]? teachersIdHighlight = null){
        using(Almacen db = new()){
            if(db.Docentes is null || (!db.Docentes.Any())){
                Program.Fail("No hay docentes registrados");
                return;
            }
            WriteLine("{0,-3} | {1,-18} | {2,-18} | {3,-30} | {4,-25} | {5}","Id","Apellido Paterno", "Apellido Materno","Nombre","Correo","Plantel");
            foreach(var docentes in db.Docentes!){
                ConsoleColor backgroundColor = ForegroundColor;
                if((teachersIdHighlight is not null) && teachersIdHighlight.Contains(docentes.DocenteId)){
                    ForegroundColor = ConsoleColor.Green;
                }
                WriteLine($"{docentes.DocenteId,-3} | {docentes.ApellidoPaterno,-18} | {docentes.ApellidoMaterno,-18} | {docentes.Nombre,-30} | {docentes.Correo,-25} | {(docentes.PlantelId == 1 ? "Colomos" : (docentes.PlantelId == 2 ? "Tonala" : "Rio Santiago"))}");
                ForegroundColor = backgroundColor;
            }
            WriteLine();
        }
    }

    public static void ListLaboratories(int[]? laboratoriesIdHighlight = null){
        using(Almacen db = new()){
            if(db.Laboratorios is null || (!db.Laboratorios.Any())){
                Program.Fail("No hay docentes registrados");
                return;
            }
            WriteLine("{0,-3} | {1,-18} | {2,-18}","Id","Nombre", "Descripcion");
            foreach(var labs in db.Laboratorios!){
                ConsoleColor backgroundColor = ForegroundColor;
                if((laboratoriesIdHighlight is not null) && laboratoriesIdHighlight.Contains(labs.LaboratorioId)){
                    ForegroundColor = ConsoleColor.Green;
                }
                WriteLine($"{labs.LaboratorioId,-3} | {labs.Nombre,-18} | {labs.Descripcion,-18}");
                ForegroundColor = backgroundColor;
            }
            WriteLine();
        }
    }
    
    public static void ListInventoryManager(int[]? inventoryManagerIdHighlight = null){
        using(Almacen db = new()){
            if(db.Almacenistas is null || (!db.Almacenistas.Any())){
                Program.Fail("No hay almacenistas registrados");
                return;
            }
            WriteLine("{0,-3} | {1,-18} | {2,-18} | {3,-30} | {4,-25} | {5}","Id","Apellido Paterno", "Apellido Materno","Nombre","Correo","Plantel");
            foreach(var almacenistas in db.Almacenistas!){
                ConsoleColor backgroundColor = ForegroundColor;
                if((inventoryManagerIdHighlight is not null) && inventoryManagerIdHighlight.Contains(almacenistas.AlmacenistaId)){
                    ForegroundColor = ConsoleColor.Green;
                }
                WriteLine($"{almacenistas.AlmacenistaId,-3} | {almacenistas.ApellidoPaterno,-18} | {almacenistas.ApellidoMaterno,-18} | {almacenistas.Nombre,-30} | {almacenistas.Correo,-25} | {(almacenistas.PlantelId == 1 ? "Colomos" : (almacenistas.PlantelId == 2 ? "Tonala" : "Rio Santiago"))}");
                ForegroundColor = backgroundColor;
            }
            WriteLine();
        }
    }
    
    public static void ListStudents(int[]? studentsIdHighlight = null){
        using(Almacen db = new()){
            if(db.Estudiantes is null || (!db.Estudiantes.Any())){
                Program.Fail("No hay estudiantes registrados");
                return;
            }
            WriteLine("{0,-10} | {1,-18} | {2,-18} | {3,-30} | {4,-10} | {5,-25} | {6}","Id","Apellido Paterno", "Apellido Materno","Nombre","Semestre","Correo","Plantel");
            foreach(var estudiantes in db.Estudiantes!){
                ConsoleColor backgroundColor = ForegroundColor;
                if((studentsIdHighlight is not null) && studentsIdHighlight.Contains(estudiantes.EstudianteId)){
                    ForegroundColor = ConsoleColor.Green;
                }
                WriteLine($"{estudiantes.EstudianteId,-10} | {estudiantes.ApellidoPaterno,-18} | {estudiantes.ApellidoMaterno,-18} | {estudiantes.Nombre,-30} | {estudiantes.SemestreId,-10} | {estudiantes.Correo,-25} | {(estudiantes.PlantelId == 1 ? "Colomos" : (estudiantes.PlantelId == 2 ? "Tonala" : "Rio Santiago"))}");
                ForegroundColor = backgroundColor;
            }
            WriteLine();
        }
    }

    // Función para el READ de la tabla almacenista
    public static void ReadAlmacenistas(){
        using (Almacen bd = new()){
            if (bd.Almacenistas is null || (!bd.Almacenistas.Any())){
                WriteLine("No se encontraron almacenistas");
            }
            else{
                WriteLine("{0,-10}|{1,-20}|{2,-20}|{3,-20}|{4,-20}|{5,-10}|{6,-10}","AlmacenistaId", "Nombre", "Apellido Paterno", "ApellidoMaterno", "Correo", "PlantelId", "UsuarioId");
                foreach (var almacenista in bd.Almacenistas){
                    Write($"{almacenista.AlmacenistaId,-13}|{almacenista.Nombre,-20}|{almacenista.ApellidoPaterno,-20}|");
                    WriteLine($"{almacenista.ApellidoMaterno,-20}|{almacenista.Correo,-20}|{almacenista.PlantelId,-10}|{almacenista.UsuarioId}");
                }
            }
        }
    }

    // Función para el READ de la tabla categorías
    public static void ReadCategorias(){
        using (Almacen bd = new()){
            if (bd.Categorias is null || (!bd.Categorias.Any())){
                WriteLine("No se encontraron categorías");
            }
            else{
                WriteLine("{0,-10}|{1,-20}|{2,-20}|{3,-20}","CategoriaId", "Nombre", "Descripcion", "Materiales");
                foreach (var cat in bd.Categorias){
                    WriteLine($"{cat.CategoriaId,-13}|{cat.Nombre,-20}|{cat.Descripcion,-20}|{cat.Materiales}");
                }
            }
        }
    }

    // Función para el READ de la tabla coordinadores
    public static void ReadCoordinadores(){
        using (Almacen bd = new()){
            if (bd.Coordinadores is null || (!bd.Coordinadores.Any())){
                WriteLine("No se encontraron coordinadores");
            }
            else{
                WriteLine("{0,-10}|{1,-20}|{2,-20}|{3,-20}|{4,-20}|{5,-10}|{6,-10}","CoordinadorId", "Nombre", "ApellidoPaterno", "ApellidoMaterno", "Correo", "PlantelId", "UsuarioId");
                foreach (var cord in bd.Coordinadores){
                    WriteLine($"{cord.CoordinadorId,-13}|{cord.Nombre,-20}|{cord.ApellidoPaterno,-20}|{cord.ApellidoMaterno,-20}|{cord.Correo,-20}|{cord.PlantelId,-10}|{cord.UsuarioId}");
                }
            }
        }
    }

    // Función para el READ de la tabla descripciones de pedidos
    public static void ReadDescPedidos(){
        using (Almacen bd = new()){
            if (bd.DescPedidos is null || (!bd.DescPedidos.Any())){
                WriteLine("No se encontraron descripciones de pedidos");
            }
            else{
                WriteLine("{0,-10}|{1,-20}|{2,-20}|{3,-20}","DescPedidoId", "Cantidad", "PedidoId", "MaterialId");
                foreach (var desc in bd.DescPedidos){
                    WriteLine($"{desc.DescPedidoId,-13}|{desc.Cantidad,-20}|{desc.PedidoId,-20}|{desc.MaterialId}");
                }
            }
        }
    }

    // Función para el READ de la tabla estudiantes
    public static void ReadEstudiantes(){
        using (Almacen bd = new()){
            if (bd.Estudiantes is null || (!bd.Estudiantes.Any())){
                WriteLine("No se encontraron estudiantes");
            }
            else
            {
                WriteLine("{0,-12}|{1,-20}|{2,-20}|{3,-20}|{4,-20}|{5,-10}|{6,-10}|{7,-10}|{8,-5}|{9,-15}","EstudianteId", "Nombre", "Apellido Paterno", "ApellidoMaterno", "Correo", "PlantelId", "UsuarioID", "SemestreId", "GrupoId", "Adeudo");
                foreach (var es in bd.Estudiantes){
                    WriteLine($"{es.EstudianteId,-12}|{es.Nombre,-20}|{es.ApellidoPaterno,-20}|{es.ApellidoMaterno,-20}|{es.Correo,-20}|{es.PlantelId,-10}|{es.UsuarioId,-10}|{es.SemestreId,-10}|{es.GrupoId,-7}|{es.Adeudo}");
                }
            }
        }
    }

    // Función para el READ de la tabla docentes
    public static void ReadDocentes(){
        using (Almacen bd = new()){
            if (bd.Docentes is null || (!bd.Docentes.Any())){
                WriteLine("No se encontraron docentes");
            }
            else{
                WriteLine("{0,-10}|{1,-20}|{2,-20}|{3,-20}|{4,-20}|{5,-10}|{6,-10}","DocenteId", "Nombre", "Apellido Paterno", "ApellidoMaterno", "Correo", "PlantelId", "UsuarioId");
                foreach (var dc in bd.Docentes){
                    WriteLine($"{dc.DocenteId,-10}|{dc.Nombre,-20}|{dc.ApellidoPaterno,-20}|{dc.ApellidoMaterno,-20}|{dc.Correo,-20}|{dc.PlantelId,-10}|{dc.UsuarioId}");
                }
            }
        }
    }

    // Función para el READ de la tabla grupos
    public static void ReadGrupos(){
        using (Almacen bd = new()){
            if (bd.Grupos is null || (!bd.Grupos.Any())){
                WriteLine("No se encontraron grupos");
            }
            else{
                WriteLine("{0,-10}|{1}", "GrupoId", "Nombre");
                foreach (var gr in bd.Grupos){
                    WriteLine($"{gr.GrupoId,-10}|{gr.Nombre}");
                }
            }
        }
    }

    // Función para el READ de la tabla laboratorios
    public static void ReadLaboratorios(){
        using (Almacen bd = new()){
            if (bd.Laboratorios is null || (!bd.Laboratorios.Any())){
                WriteLine("No se encontraron laboratorios");
            }
            else{
                WriteLine("{0,-10}|{1,-20}|{2}","LaboratorioId", "Nombre", "Descripcion");
                foreach (var lab in bd.Laboratorios){
                    WriteLine($"{lab.LaboratorioId,-10}|{lab.Nombre,-20}|{lab.Descripcion}");
                }
            }
        }
    }

    // Función para el READ de la tabla mantenimientos
    public static void ReadMantenimientos(){
        using (Almacen bd = new()){
            if (bd.Mantenimientos is null || (!bd.Mantenimientos.Any())){
                WriteLine("No se encontraron mantenimientos");
            }
            else{
                WriteLine("{0,-10}|{1,-20}|{2}","MantenimientoId", "Nombre", "Descripcion");
                foreach (var man in bd.Mantenimientos){
                    WriteLine($"{man.MantenimientoId,-10}|{man.Nombre,-20}|{man.Descripcion}");
                }
            }
        }
    }

    // Función para el READ de la tabla marcas
    public static void ReadMarcas(){
        using (Almacen bd = new()){
            if (bd.Marcas is null || (!bd.Marcas.Any())){
                WriteLine("No se encontraron marcas");
            }
            else{
                WriteLine("{0,-10}|{1,-20}|{2}","MarcaId", "Nombre", "Descripcion");
                foreach (var mar in bd.Marcas){
                    WriteLine($"{mar.MarcaId,-10}|{mar.Nombre,-20}|{mar.Descripcion}");
                }
            }
        }
    }

    // Función para el READ de la tabla materiales
    public static void ReadMateriales(){
        using (Almacen bd = new()){
            if (bd.Materiales is null || (!bd.Materiales.Any())){
                WriteLine("No se encontraron materiales");
            }
            else{
                WriteLine("{0,-10}|{1,-20}|{2,-15}|{3}","MaterialId", "ModeloId", "Descripcion", "YearEntrada");
                foreach (var mat in bd.Materiales){
                    WriteLine($"{mat.MaterialId,-10}|{mat.ModeloId,-20}|{mat.Descripcion,15}|{mat.YearEntrada}");
                }
            }
        }
    }

    // Función para el READ de la tabla modelos
    public static void ReadModelos(){
        using (Almacen bd = new()){
            if (bd.Modelos is null || (!bd.Modelos.Any())){
                WriteLine("No se encontraron modelos");
            }
            else{
                WriteLine("{0,-10}|{1,-20}|{2}","ModeloId", "Nombre", "Descripcion");
                foreach (var mod in bd.Modelos){
                    WriteLine($"{mod.ModeloId,-10}|{mod.Nombre,-20}|{mod.Descripcion}");
                }
            }
        }
    }

    // Función para el READ de la tabla pedidos
    public static void ReadPedidos(){
        using (Almacen bd = new()){
            if (bd.Pedidos is null || (!bd.Pedidos.Any())){
                WriteLine("No se encontraron pedidos");
            }
            else{
                WriteLine("{0,-10}|{1,-20}|{2,-20}|{3,-20}|{4,-20}|{5,-10}|{6,-10}","PedidoId", "Fecha", "LaboratorioId", "HoraEntrega", "HoraDevolucion", "EstudianteId", "DocenteId");
                foreach (var ped in bd.Pedidos){
                    WriteLine($"{ped.PedidoId,-13}|{ped.Fecha,-20}|{ped.LaboratorioId,-20}|{ped.HoraEntrega,-20}|{ped.HoraDevolucion,-20}|{ped.EstudianteId,-10}|{ped.DocenteId}");
                }
            }
        }
    }

    // Función para el READ de la tabla planteles
    public static void ReadPlanteles(){
        using (Almacen bd = new()){
            if (bd.Planteles is null || (!bd.Planteles.Any())){
                WriteLine("No se encontraron planteles");
            }
            else{
                WriteLine("{0,-10}|{1,-20}|{2,-82}|{3}","PlantelId", "Nombre", "Direccion", "Telefono");
                foreach (var pl in bd.Planteles){
                    WriteLine($"{pl.PlantelId,-10}|{pl.Nombre,-20}|{pl.Direccion,-82}|{pl.Telefono}");
                }
            }
        }
    }

    // Función para el READ de la tabla reportes de mantenimiento
    public static void ReadReporteMantenimientos(){
        using (Almacen bd = new()){
            if (bd.ReporteMantenimientos is null || (!bd.ReporteMantenimientos.Any())){
                WriteLine("No se encontraron reportes de mantenimiento");
            }
            else{
                WriteLine("{0,-10}|{1,-20}|{2,-20}|{3,-20}","ReporteMantenimientoId", "Fecha", "MantenimientoId", "MaterialId");
                foreach (var rp in bd.ReporteMantenimientos){
                    WriteLine($"{rp.ReporteMantenimientoId,-13}|{rp.Fecha,-20}|{rp.MantenimientoId,-20}|{rp.MaterialId,-20}");
                }
            }
        }
    }

    // Función para el READ de la tabla semestres
    public static void ReadSemestres(){
        using (Almacen bd = new()){
            if (bd.Semestres is null || (!bd.Semestres.Any())){
                WriteLine("No se encontraron semestres");
            }
            else{
                WriteLine("{0,-10}|{1}","SemestreId", "Numero");
                foreach (var sm in bd.Semestres){
                    WriteLine($"{sm.SemestreId,-10}|{sm.Numero}");
                }
            }
        }
    }

    // Función para el READ de la tabla usuarios
    public static void ReadUsuarios(){
        using (Almacen bd = new()){
            if (bd.Usuarios is null || (!bd.Usuarios.Any())){
                WriteLine("No se encontraron usuarios");
            }
            else{
                WriteLine("{0,-10}|{1,-20}|{2}","UsuarioId", "Usuario1", "Password");
                foreach (var us in bd.Usuarios){
                    WriteLine($"{us.UsuarioId,-10}|{us.Usuario1,-20}|{us.Password}");
                }
            }
        }
    }

    //Funtions read for queries:

    public static void ReadQueryCategorias(IQueryable<Categoria> categorias){
        using (Almacen bd = new()){
            WriteLine("{0,-10}|{1,-20}|{2,-20}|{3,-20}","CategoriaId", "Nombre", "Descripcion", "Acceso");
            foreach (var cat in categorias){
                WriteLine($"{cat.CategoriaId,-13}|{cat.Nombre,-20}|{cat.Descripcion,-20}|{cat.Acceso}");
            }
        }
    }

    public static void ReadQueryDocentes(IQueryable<Docente> docentes){
        using (Almacen bd = new()){
            WriteLine("{0,-10}|{1,-20}|{2,-20}|{3,-20}|{4,-20}|{5,-10}|{6,-10}","DocenteId", "Nombre", "Apellido Paterno", "ApellidoMaterno", "Correo", "PlantelId", "UsuarioId");
            foreach (var dc in docentes){
                WriteLine($"{dc.DocenteId,-10}|{dc.Nombre,-20}|{dc.ApellidoPaterno,-20}|{dc.ApellidoMaterno,-20}|{dc.Correo,-20}|{dc.PlantelId,-10}|{dc.UsuarioId}");
            }
        }
    }
}
