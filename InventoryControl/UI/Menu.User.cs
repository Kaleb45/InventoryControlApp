using System;
using AlmacenDataContext;
using AlmacenSQLiteEntities;

public static partial class UI
{
    static void StudentUI(Estudiante? estudiante)
    {
        do
        {
            Console.WriteLine("Alumno Menu:");
            Console.WriteLine("1: Ver material");
            Console.WriteLine("2: Solicitar un material");
            Console.WriteLine("3: Ver solicitudes");
            Console.WriteLine("4: Cambiar contraseña");
            Console.WriteLine("9: Logout");
            String option = Console.ReadLine()??"";
            Console.Clear();

            switch (option)
            {
                case "9":
                    return;
                default:
                    break;
            }
        } while (true);
    }

    static void TeacherUI(Docente? docente)
    {
        do
        {
            Console.WriteLine("Profesor Menu:");
            Console.WriteLine("1: Historial de solicitudes");
            Console.WriteLine("2: Ver solicitudes");
            Console.WriteLine("3: Hacer una solicitud");
            Console.WriteLine("4: Ver materiales");
            Console.WriteLine("5: Cambiar contraseña");
            Console.WriteLine("9: Logout");
            String option = Console.ReadLine()??"";
            Console.Clear();

            switch (option)
            {
                case "9":
                    return;
                default:
                    break;
            }
        } while (true);
    }

    static void InventoryManagerUI(Almacenista? almacenista)
    {
        do
        {
            Console.WriteLine("Almacenista Menu:");
            Console.WriteLine("1: Administrar inventario");
            Console.WriteLine("2: Ver solicitudes");
            Console.WriteLine("3: Generar informes");
            Console.WriteLine("4: Agregar pedido");
            Console.WriteLine("5: Modificar pedido");
            Console.WriteLine("6: Eliminar pedido");
            Console.WriteLine("7: Cambiar contraseña");
            Console.WriteLine("8: Agendar mantenimiento");
            Console.WriteLine("9: Logout");
            String option = Console.ReadLine()??"";
            Console.Clear();

            switch (option)
            {
                case "1":
                    ManageInventory();
                    break;
                case "9":
                    return;
                default:
                    break;
            }
        } while (true);
    }

    static void AdministratorUI(Coordinador? coordinador)
    {
        do
        {
            Console.WriteLine("Administrador Menu:");
            Console.WriteLine("1: Eliminar pedido");
            Console.WriteLine("2: Eliminar maestro");
            Console.WriteLine("3: Eliminar almacenista");
            Console.WriteLine("4: Eliminar estudiante");
            Console.WriteLine("5: Eliminar mantenimiento");
            Console.WriteLine("6: Modificar pedido");
            Console.WriteLine("7: Modificar maestro");
            Console.WriteLine("8: Modificar almacenista");
            Console.WriteLine("9: Modificar estudiante"); 
            Console.WriteLine("10: Modificar mantenimiento");
            Console.WriteLine("11: Agregar pedido");
            Console.WriteLine("12: Agregar maestro");
            Console.WriteLine("13: Agregar almacenista");
            Console.WriteLine("14: Agregar estudiante");
            Console.WriteLine("15: Agregar mantenimiento");
            Console.WriteLine("16: Cambiar contraseña");
            Console.WriteLine("17: Logout");
            String option = Console.ReadLine()??"";
            Console.Clear();

            switch (option)
            {
                case "1":
                    CrudFuntions.ListOrders();
                    int deletedOrders = CrudFuntions.DeleteOrders();
                    Console.WriteLine($"{deletedOrders} pedidos eliminados.");
                    Console.WriteLine();
                    CrudFuntions.ListOrders();
                    break;
                case "2":
                    CrudFuntions.ListTeachers();
                    int deletedTeachers = CrudFuntions.DeleteTeachers();
                    Console.WriteLine($"{deletedTeachers} maestros eliminados.");
                    Console.WriteLine();
                    CrudFuntions.ListTeachers();
                    break;
                case "3":
                    CrudFuntions.ListInventoryManager();
                    int deletedInventoryManager = CrudFuntions.DeleteInventoryManager();
                    Console.WriteLine($"{deletedInventoryManager} almacenistas eliminados.");
                    Console.WriteLine();
                    CrudFuntions.ListInventoryManager();
                    break;
                case "4":
                    CrudFuntions.ListStudents();
                    int deletedStudents = CrudFuntions.DeleteStudents();
                    Console.WriteLine($"{deletedStudents} estudiantes eliminados.");
                    Console.WriteLine();
                    CrudFuntions.ListStudents();
                    break;
                case "9":
                    return;
                default:
                    break;
            }
        } while (true);
    }
}