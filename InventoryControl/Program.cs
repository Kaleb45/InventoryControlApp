using AlmacenDataContext;
using AlmacenSQLiteEntities;
using System;
using static System.Console;

internal partial class Program
{
    static void Main()
    {
        Console.Clear();
        Almacen db = new();
        WriteLine($"Provider: {db.Database.ProviderName}");
        UI.Manage();
    }
}