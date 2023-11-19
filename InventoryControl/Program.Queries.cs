using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking; // CollectionEntry
using System;
using static System.Console;
using AlmacenDataContext;
using AlmacenSQLiteEntities;

partial class Program
{
    public static void StudentOrders(){
        using(Almacen db = new ()){
            IQueryable<DescPedido> descPedidos = db.DescPedidos.Include(d => d.Pedido).Include(d => d.Material).Where(d => d.Pedido.EstudianteId == 20300697);
            foreach (var pedido in descPedidos)
            {
                WriteLine($"{pedido.Cantidad}{pedido.Material.Categoria.Nombre}|{pedido.Pedido.Fecha}|{pedido.Pedido.Docente.Nombre}|{pedido.Pedido.Estudiante.Nombre}");
            }
        }
    }
}