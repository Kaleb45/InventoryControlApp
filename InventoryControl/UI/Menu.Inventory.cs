using System;
using AlmacenDataContext;
using AlmacenSQLiteEntities;

public static partial class UI
{
    static void ManageInventory()
    {
        do
        {
            Console.WriteLine("Administrar inventario Menu:");
            Console.WriteLine("1: Agregar nuevo material");
            Console.WriteLine("2: Modificar material");
            Console.WriteLine("3: Eliminar material");
            Console.WriteLine("4: Salir");
            String option = Console.ReadLine()??"";
            Console.Clear();

            switch (option)
            {
                case "1":
                    
                    break;
                case "2":
                    
                    break;
                case "3":
                    CrudFuntions.ListMaterials();
                    int deletedMaterials = CrudFuntions.DeleteMaterials();
                    Console.WriteLine($"{deletedMaterials} materiales eliminados.");
                    Console.WriteLine();
                    CrudFuntions.ListMaterials();
                    break;
                case "4":
                    return;
                default:
                    break;
            }
        } while (true);
    }
}