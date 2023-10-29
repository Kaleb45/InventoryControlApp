using System;
using Proyecto_Almacen.AutoGen;
public static partial class UI
{
    static void LogIn()
    {
        Console.WriteLine("Ingresa tu usuario:");
        string userName = Console.ReadLine();

        Console.WriteLine("Ingresa tu contraseña:");
        string password = Console.ReadLine();

        using (Almacen db = new())
        {
            var user = db.Usuarios.FirstOrDefault(u => u.Usuario1 == userName && u.Password == password);
            if (user != null)
            {
                Console.Clear();
                Console.WriteLine($"¡Bienvenido, {userName}!");
                Console.WriteLine("");
                if (user.Docentes.Any())
                {
                    TeacherUI();
                }
                else if (user.Estudiantes.Any())
                {
                    StudentUI();
                }
                else if (user.Almacenistas.Any())
                {
                    InventoryManagerUI();
                }
                else if (user.Coordinadores.Any())
                {
                    AdministratorUI();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Usuario o contraseña incorrectos. Inténtalo nuevamente.");
            }
        }
    }
}
