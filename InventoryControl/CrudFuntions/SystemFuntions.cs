using System;
using AlmacenDataContext;
using AlmacenSQLiteEntities;
public static partial class CrudFuntions{
    public static void OrderMaterial(int typeOfUser, int userID){
        using (Almacen db = new()){
            var user = db.Usuarios.FirstOrDefault(u => u.UsuarioId == userID);
            Pedido pedido = new Pedido();
            switch(typeOfUser){
                case 1:

                break;
                case 2:

                break;
                case 3:

                break;
                case 4:

                break;
            }
        }
    }
    public static void GetDataOfOrder(Pedido pedido, int typeOfUser){
    }
}