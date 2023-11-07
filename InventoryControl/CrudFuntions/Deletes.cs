using System;
using AlmacenDataContext;
using AlmacenSQLiteEntities;
public static partial class CrudFuntions{
    public static int DeleteMaterials(){
        using(Almacen db = new()){
            int materialId = SearchId();
            Material? materiales = db.Materiales!.FirstOrDefault(m => m.MaterialId == materialId);
            if((materiales is null)){
                WriteLine("No se encontro un material para eliminar");
            }
            else{
                if(db.Materiales is null) return 0;
                db.Materiales.RemoveRange(materiales);
            }
            int affected = db.SaveChanges();
            return affected;
        }
    }
    
    public static int DeleteOrders(){
        using(Almacen db = new()){
            int pedidoId = SearchId();
            Pedido? pedidos = db.Pedidos!.FirstOrDefault(p => p.PedidoId == pedidoId);
            if((pedidos is null)){
                WriteLine("No se encontro un pedido para eliminar");
            }
            else{
                if(db.Pedidos is null) return 0;
                db.Pedidos.RemoveRange(pedidos);
            }
            int affected = db.SaveChanges();
            return affected;
        }
    }
    
    public static int DeleteTeachers(){
        using(Almacen db = new()){
            int docenteId = SearchId();
            Docente? docentes = db.Docentes!.FirstOrDefault(p => p.DocenteId == docenteId);
            if((docentes is null)){
                WriteLine("No se encontro un docente para eliminar");
            }
            else{
                if(db.Docentes is null) return 0;
                db.Docentes.RemoveRange(docentes);
            }
            int affected = db.SaveChanges();
            return affected;
        }
    }
    
    public static int DeleteInventoryManager(){
        using(Almacen db = new()){
            int almacenistaId = SearchId();
            Almacenista? almacenistas = db.Almacenistas!.FirstOrDefault(p => p.AlmacenistaId == almacenistaId);
            if((almacenistas is null)){
                WriteLine("No se encontro un almacenista para eliminar");
            }
            else{
                if(db.Almacenistas is null) return 0;
                db.Almacenistas.RemoveRange(almacenistas);
            }
            int affected = db.SaveChanges();
            return affected;
        }
    }
    
    public static int DeleteStudents(){
        using(Almacen db = new()){
            int estudianteId = SearchId();
            Estudiante? estudiantes = db.Estudiantes!.FirstOrDefault(p => p.EstudianteId == estudianteId);
            if((estudiantes is null)){
                WriteLine("No se encontro un estudiante para eliminar");
            }
            else{
                if(db.Estudiantes is null) return 0;
                db.Estudiantes.RemoveRange(estudiantes);
            }
            int affected = db.SaveChanges();
            return affected;
        }
    }
}