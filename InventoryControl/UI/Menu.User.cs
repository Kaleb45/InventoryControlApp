using System;
using AlmacenDataContext;
using AlmacenSQLiteEntities;

public static partial class UI
{
    static void StudentUI(){
        do{
            WriteLine("Alumno Menu:");
            WriteLine("1: Solicitar un material");
            WriteLine("2: Ver solicitudes");
            WriteLine("3: Cambiar contraseña");
            WriteLine("9: Logout");
            String option = ReadLine()??"";
            Clear();

            switch (option){
                case "9":
                    return;
                default:
                    break;
            }
        } while (true);
    }

    static void TeacherUI(){
        do{
            WriteLine("Profesor Menu:");
            WriteLine("1: Historial de solicitudes");
            WriteLine("2: Ver solicitudes");
            WriteLine("3: Hacer una solicitud");
            WriteLine("4: Cambiar contraseña");
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

    static void InventoryManagerUI()
    {
        do
        {
            WriteLine("Almacenista Menu:");
            WriteLine("1: Administrar inventario");
            WriteLine("2: Ver solicitudes");
            WriteLine("3: Generar informes");
            WriteLine("4: Cambiar contraseña");
            WriteLine("9: Logout");
            String option = ReadLine()??"";
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

    static void AdministratorUI()
    {
        do
        {
            WriteLine("Administrador Menu:");
            WriteLine("1: Opción 1");
            WriteLine("2: Opción 2");
            WriteLine("3: Opción 3");
            WriteLine("4: Opción 3");
            WriteLine("5: Cambiar contraseña");
            WriteLine("9: Logout");
            String option = ReadLine()??"";
            Clear();

            switch (option)
            {
                case "1":
                    CrudFuntions.ListOrders();
                    int deletedOrders = CrudFuntions.DeleteOrders();
                    WriteLine($"{deletedOrders} pedidos eliminados.");
                    WriteLine();
                    CrudFuntions.ListOrders();
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