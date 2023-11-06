using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using AlmacenDataContext;
using AlmacenSQLiteEntities;
using System.Linq;
public static partial class CrudFuntions
{
    public static int SearchId()
    {
        Program.SectionTitle("Material");
        string? input;
        int Id;
        do
        {
            WriteLine("Ingresa el ID del material: ");
            input = ReadLine();
        } while (!int.TryParse(input, out Id));
        
        return Id;
    }
    public static void ListMaterials(int[]? materialIdHighlight = null)
    {
        using(Almacen db = new())
        {
            if(db.Materiales is null || (!db.Materiales.Any())) // Para revisar si no esta vacio o es null
            {
                Program.Fail("No hay materiales registrados");
                return;
            }
            
            WriteLine("{0,-3} | {1,-35} | {2,8} | {3,5} | {4}","Id","Descripcion","Año de Entrada","Modelo","Marca");

            foreach(var material in db.Materiales!)
            {
                ConsoleColor backgroundColor = ForegroundColor;
                if((materialIdHighlight is not null) && materialIdHighlight.Contains(material.MaterialId))
                {
                    ForegroundColor = ConsoleColor.Green;
                }

                WriteLine($"{material.MaterialId,-3} | {material.Descripcion,-35} | {material.YearEntrada,-14} | {material.Modelo.Nombre,6} | {material.Marca.Nombre}");
                ForegroundColor = backgroundColor;
            }
            WriteLine();
        }
    }
    
    public static void ListOrders(int[]? ordersIdHighlight = null)
    {
        using(Almacen db = new())
        {
            if(db.Pedidos is null || (!db.Pedidos.Any())) // Para revisar si no esta vacio o es null
            {
                Program.Fail("No hay pedidos registrados");
                return;
            }
            
            WriteLine("{0,-3} | {1,-35} | {2,-8} | {3,-25} | {4,-25} | {5,-10} | {6,-10} | {7}","Id","Fecha","Laboratorio","Hora de Entrega","Hora de Devolucion","Estudiante","Docente","Aprovado");

            foreach(var pedidos in db.Pedidos!)
            {
                ConsoleColor backgroundColor = ForegroundColor;
                if((ordersIdHighlight is not null) && ordersIdHighlight.Contains(pedidos.PedidoId))
                {
                    ForegroundColor = ConsoleColor.Green;
                }

                WriteLine($"{pedidos.PedidoId,-3} | {pedidos.Fecha,-35} | {pedidos.Laboratorio.Nombre,-11} | {pedidos.HoraEntrega,-6} | {pedidos.HoraDevolucion,-5} | {pedidos.Estudiante.Nombre,-10} | {pedidos.Docente.Nombre,-10} | {(pedidos.Estado ? "SI" : "NO")}");
                ForegroundColor = backgroundColor;
            }
            WriteLine();
        }
    }
    
    public static void ListTeachers(int[]? teachersIdHighlight = null)
    {
        using(Almacen db = new())
        {
            if(db.Docentes is null || (!db.Docentes.Any())) // Para revisar si no esta vacio o es null
            {
                Program.Fail("No hay docentes registrados");
                return;
            }
            
            WriteLine("{0,-3} | {1,-18} | {2,-18} | {3,-30} | {4,-25} | {5}","Id","Apellido Paterno", "Apellido Materno","Nombre","Correo","Plantel");

            foreach(var docentes in db.Docentes!)
            {
                ConsoleColor backgroundColor = ForegroundColor;
                if((teachersIdHighlight is not null) && teachersIdHighlight.Contains(docentes.DocenteId))
                {
                    ForegroundColor = ConsoleColor.Green;
                }

                WriteLine($"{docentes.DocenteId,-3} | {docentes.ApellidoPaterno,-18} | {docentes.ApellidoMaterno,-18} | {docentes.Nombre,-30} | {docentes.Correo,-25} | {(docentes.PlantelId == 1 ? "Colomos" : (docentes.PlantelId == 2 ? "Tonala" : "Rio Santiago"))}");
                ForegroundColor = backgroundColor;
            }
            WriteLine();
        }
    }
    
    public static void ListInventoryManager(int[]? inventoryManagerIdHighlight = null)
    {
        using(Almacen db = new())
        {
            if(db.Almacenistas is null || (!db.Almacenistas.Any())) // Para revisar si no esta vacio o es null
            {
                Program.Fail("No hay almacenistas registrados");
                return;
            }
            
            WriteLine("{0,-3} | {1,-18} | {2,-18} | {3,-30} | {4,-25} | {5}","Id","Apellido Paterno", "Apellido Materno","Nombre","Correo","Plantel");

            foreach(var almacenistas in db.Almacenistas!)
            {
                ConsoleColor backgroundColor = ForegroundColor;
                if((inventoryManagerIdHighlight is not null) && inventoryManagerIdHighlight.Contains(almacenistas.AlmacenistaId))
                {
                    ForegroundColor = ConsoleColor.Green;
                }

                WriteLine($"{almacenistas.AlmacenistaId,-3} | {almacenistas.ApellidoPaterno,-18} | {almacenistas.ApellidoMaterno,-18} | {almacenistas.Nombre,-30} | {almacenistas.Correo,-25} | {(almacenistas.PlantelId == 1 ? "Colomos" : (almacenistas.PlantelId == 2 ? "Tonala" : "Rio Santiago"))}");
                ForegroundColor = backgroundColor;
            }
            WriteLine();
        }
    }
    
    public static void ListStudents(int[]? studentsIdHighlight = null)
    {
        using(Almacen db = new())
        {
            if(db.Estudiantes is null || (!db.Estudiantes.Any())) // Para revisar si no esta vacio o es null
            {
                Program.Fail("No hay estudiantes registrados");
                return;
            }
            
            WriteLine("{0,-10} | {1,-18} | {2,-18} | {3,-30} | {4,-10} | {5,-25} | {6}","Id","Apellido Paterno", "Apellido Materno","Nombre","Semestre","Correo","Plantel");

            foreach(var estudiantes in db.Estudiantes!)
            {
                ConsoleColor backgroundColor = ForegroundColor;
                if((studentsIdHighlight is not null) && studentsIdHighlight.Contains(estudiantes.EstudianteId))
                {
                    ForegroundColor = ConsoleColor.Green;
                }

                WriteLine($"{estudiantes.EstudianteId,-10} | {estudiantes.ApellidoPaterno,-18} | {estudiantes.ApellidoMaterno,-18} | {estudiantes.Nombre,-30} | {estudiantes.SemestreId,-10} | {estudiantes.Correo,-25} | {(estudiantes.PlantelId == 1 ? "Colomos" : (estudiantes.PlantelId == 2 ? "Tonala" : "Rio Santiago"))}");
                ForegroundColor = backgroundColor;
            }
            WriteLine();
        }
    }

    
}
