using System;
using Proyecto_Almacen.AutoGen;

public static partial class UI
{
    static void StudentUI()
    {
        do
        {
            Console.WriteLine("Alumno Menu:");
            Console.WriteLine("1: Solicitar un material");
            Console.WriteLine("2: Ver solicitudes");
            Console.WriteLine("3: Cambiar contraseña");
            Console.WriteLine("9: Logout");
            String option = Console.ReadLine();
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
    

    static void TeacherUI()
    {
        do
        {
            Console.WriteLine("Profesor Menu:");
            Console.WriteLine("1: Historial de solicitudes");
            Console.WriteLine("2: Ver solicitudes");
            Console.WriteLine("3: Hacer una solicitud");
            Console.WriteLine("4: Cambiar contraseña");
            Console.WriteLine("9: Logout");
            String option = Console.ReadLine();
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

    static void InventoryManagerUI()
    {
        do
        {
            Console.WriteLine("Almacenista Menu:");
            Console.WriteLine("1: Administrar inventario");
            Console.WriteLine("2: Ver solicitudes");
            Console.WriteLine("3: Generar informes");
            Console.WriteLine("4: Cambiar contraseña");
            Console.WriteLine("9: Logout");
            String option = Console.ReadLine();
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

    static void AdministratorUI()
    {
        string option;
        do
        {
            Console.WriteLine("Administrador Menu:");
            Console.WriteLine("1: Agregar un nuevo Docente");
            Console.WriteLine("2: Agregar un nuevo Almacenista");
            Console.WriteLine("3: Cambiar contraseña");
            Console.WriteLine("4: Logout");
            option = Console.ReadLine();
            Console.Clear();

            switch (option)
            {
                case "1":
                    SignUpDocente();
                    break;
                default:
                    Console.WriteLine("Opción invalida");
                    break;
            }
        } while (option != "4");
    }
}
