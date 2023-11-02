using AlmacenDataContext;
using AlmacenSQLiteEntities;
public static partial class UI
{
    public static void Manage()
    {
        while (true)
        {
            Console.WriteLine("1: Login ");
            Console.WriteLine("2: Signup");
            string res = Console.ReadLine();
            Console.Clear();
            switch (res)
            {
                case "1":
                    LogIn();
                    break;
                case "2":
                    SignUp();
                    break;
                default:
                    Console.WriteLine("Opción no válida, intentelo de nuevo");
                    break;
            }
        }
    }

    static UI()
    {
    }
}
