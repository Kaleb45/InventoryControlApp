using InventoryControl;
using System;
using static System.Console;

internal partial class Program
{
    static void Main()
    {
        Almacen db = new();
        WriteLine($"Provider: {db.Database.ProviderName}");
    }
}