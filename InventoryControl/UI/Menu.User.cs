using System;
using AlmacenDataContext;
using AlmacenSQLiteEntities;

public static partial class UI{
    static void StudentUI(Estudiante? estudiante){
        do{
            WriteLine("Alumno Menu:");
            WriteLine("1: Ver materiales"); //check
            WriteLine("2: Solicitar un material"); //
            WriteLine("3: Ver solicitudes");
            WriteLine("4: Cambiar contraseña");
            WriteLine("9: Logout");
            String option = ReadLine()??"";
            Clear();
            switch (option){
                case "1":
                    CrudFuntions.ListCategories(2);
                    break;
                case "2":
                    CrudFuntions.OrderMaterial(2,estudiante.UsuarioId);
                    break;
                case "3":
                    CrudFuntions.ListOrders(2,estudiante.EstudianteId);
                    break;
                case "9":
                    return;
                default:
                    break;
            }
        } while (true);
    }

    static void TeacherUI(Docente? docente){
        do{
            WriteLine("Profesor Menu:");
            WriteLine("1: Historial de solicitudes");
            WriteLine("2: Ver solicitudes");
            WriteLine("3: Hacer una solicitud");
            WriteLine("4: Ver materiales");
            WriteLine("5: Cambiar contraseña");
            WriteLine("9: Logout");

            String option = ReadLine()??"";
            Clear();

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
            WriteLine("Almacenista Menu:");
            WriteLine("1: Administrar inventario");
            WriteLine("2: Ver solicitudes");
            WriteLine("3: Generar informes");
            WriteLine("4: Agregar pedido");
            WriteLine("5: Modificar pedido");
            WriteLine("6: Eliminar pedido");
            WriteLine("7: Cambiar contraseña");
            WriteLine("8: Agendar mantenimiento");
            WriteLine("9: Logout");

            string option = ReadLine()??"";
            Clear();

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
            WriteLine("Administrador Menu:");
            WriteLine("1: Eliminar pedido");
            WriteLine("2: Eliminar maestro");
            WriteLine("3: Eliminar almacenista");
            WriteLine("4: Eliminar estudiante");
            WriteLine("5: Eliminar mantenimiento");
            WriteLine("6: Modificar pedido");
            WriteLine("7: Modificar maestro");
            WriteLine("8: Modificar almacenista");
            WriteLine("9: Modificar estudiante"); 
            WriteLine("10: Modificar mantenimiento");
            WriteLine("11: Agregar pedido");
            WriteLine("12: Agregar maestro");
            WriteLine("13: Agregar almacenista");
            WriteLine("14: Agregar estudiante");
            WriteLine("15: Agregar mantenimiento");
            WriteLine("16: Cambiar contraseña");
            WriteLine("17: Logout");
            String option = ReadLine()??"";
            Clear();

            switch (option)
            {
                case "1":
                    CrudFuntions.ListOrdersWithHighlight();
                    int deletedOrders = CrudFuntions.DeleteOrders();
                    WriteLine($"{deletedOrders} pedidos eliminados.");
                    WriteLine();
                    CrudFuntions.ListOrdersWithHighlight();
                    break;
                case "2":
                    CrudFuntions.ListTeachers();
                    int deletedTeachers = CrudFuntions.DeleteTeachers();
                    WriteLine($"{deletedTeachers} maestros eliminados.");
                    WriteLine();
                    CrudFuntions.ListTeachers();
                    break;
                case "3":
                    CrudFuntions.ListInventoryManager();
                    int deletedInventoryManager = CrudFuntions.DeleteInventoryManager();
                    WriteLine($"{deletedInventoryManager} almacenistas eliminados.");
                    WriteLine();
                    CrudFuntions.ListInventoryManager();
                    break;
                case "4":
                    CrudFuntions.ListStudents();
                    int deletedStudents = CrudFuntions.DeleteStudents();
                    WriteLine($"{deletedStudents} estudiantes eliminados.");
                    WriteLine();
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