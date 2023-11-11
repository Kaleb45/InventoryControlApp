using System;
using AlmacenDataContext;
using AlmacenSQLiteEntities;

public static partial class UI
{
    static void ManageInventory()
    {
        do
        {
            WriteLine("Administrar inventario Menu:");
            WriteLine("1: Agregar nuevo material");
            WriteLine("2: Modificar material");
            WriteLine("3: Eliminar material");
            WriteLine("4: Salir");
            String option = ReadLine()??"";
            Clear();

            switch (option)
            {
                case "1":
                    
                    break;
                case "2":
                    
                    break;
                case "3":
                    CrudFuntions.ListMaterialsWithHighlight();
                    int deletedMaterials = CrudFuntions.DeleteMaterials();
                    WriteLine($"{deletedMaterials} materiales eliminados.");
                    WriteLine();
                    CrudFuntions.ListMaterialsWithHighlight();
                    break;
                case "4":
                    return;
                default:
                    break;
            }
        } while (true);
    }
}