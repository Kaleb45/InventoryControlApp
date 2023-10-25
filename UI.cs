using System;

public static class UI
{
    public static void Manage()
    {

    }

    static void LogIn()
    {

    }
    public static void SignUp() 
    {
        
    }


    static void StudentUI()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Alumno Menu:");
            Console.WriteLine("1: Solicitar un material");
            Console.WriteLine("2: Ver solicitudes");
            Console.WriteLine("3: Cambiar contraseña");
            String option = Console.ReadLine();
        } while (true);
    }

    static void TeacherUI()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Profesor Menu:");
            Console.WriteLine("1: Historial de solicitudes");
            Console.WriteLine("2: Ver solicitudes");
            Console.WriteLine("3: Hacer una solicitud");
            Console.WriteLine("4: Cambiar contraseña");
        } while (true);
    }

    static void InventoryManagerUI()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Almacenista Menu:");
            Console.WriteLine("1: Administrar inventario");
            Console.WriteLine("2: Ver solicitudes");
            Console.WriteLine("3: Generar informes");
            Console.WriteLine("4: Cambiar contraseña");
        } while(true);
    }

    static void AdministratorUI()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Administrador Menu:");
            Console.WriteLine("1: Opción 1");
            Console.WriteLine("2: Opción 2");
            Console.WriteLine("3: Opción 3");
            Console.WriteLine("4: Cambiar contraseña");
        } while(true);
    }

    static UI()
    {
    }
}
