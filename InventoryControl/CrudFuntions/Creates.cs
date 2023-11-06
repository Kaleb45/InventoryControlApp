using System;
using AlmacenDataContext;
using AlmacenSQLiteEntities;
public static partial class CrudFuntions{
    public static void AddMarca(Marca marca){
        using (Almacen db = new()){
            Clear();
            db.Marcas.Add(marca);
            db.SaveChanges();
        }
    }

    public static void AddModelo(Modelo modelo){
        using (Almacen db = new()){
            Clear();
            db.Modelos.Add(modelo);
            db.SaveChanges();
        }
    }

    public static void AddCategoria(Categoria categoria){
        using (Almacen db = new()){
            Clear();
            db.Categorias.Add(categoria);
            db.SaveChanges();
        }
    }

    public static void AddLaboratorio(Laboratorio laboratorio){
        using (Almacen db = new()){
            Clear();
            db.Laboratorios.Add(laboratorio);
            db.SaveChanges();
        }
    }

    public static void AddMantenimiento(Mantenimiento mantenimiento){
        using (Almacen db = new()){
            Clear();
            db.Mantenimientos.Add(mantenimiento);
            db.SaveChanges();
        }
    }

    public static void AddMaterial(Material material){
        using (Almacen db = new Almacen()){
            Clear();
            db.Materiales.Add(material);
            db.SaveChanges();
        }
    }

    public static void AddGrupo(Grupo grupo){
        using (Almacen db = new Almacen()){
            Clear();
            db.Grupos.Add(grupo);
            db.SaveChanges();
        } 
    }

    public static void AddRReporteMantenimiento(ReporteMantenimiento Reporte){
        using (Almacen db = new Almacen()){
            Clear();
            db.ReporteMantenimientos.Add(Reporte);
            db.SaveChanges();
        } 
    }

    public static void AddPedido(Pedido pedido){
        using (Almacen db = new Almacen()){
            Clear();
            db.Pedidos.Add(pedido);
            db.SaveChanges();
        } 
    }

    public static void AddDescPedido(DescPedido descPedido){
        using (Almacen db = new Almacen()){
            Clear();
            db.DescPedidos.Add(descPedido);
            db.SaveChanges();
        } 
    }
}
