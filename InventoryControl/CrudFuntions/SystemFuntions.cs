using System;
using AlmacenDataContext;
using AlmacenSQLiteEntities;
public static partial class CrudFuntions{
    public static void OrderMaterial(int typeOfUser, int? userID){
        using (Almacen db = new()){
            Pedido pedido = new Pedido();
            DescPedido descPedido = new DescPedido();
            pedido = GetDataOfOrder(userID,typeOfUser);
            GeneralSearchCategory(2);
            descPedido.MaterialId = UI.GetMaterialID(SearchId());
            WriteLine("Ingresa la cantidad:");
            descPedido.Cantidad = int.Parse(ReadLine());
            AddPedido(pedido, descPedido);
        }
    }

    public static Pedido GetDataOfOrder(int? userID, int typeOfUser){
        Pedido pedido = new Pedido();
        string? input;
        int LabID;
        Program.SectionTitle("Vamos a hacer un pedido!!!");
        do{
            WriteLine("Ingresa la fecha");
            input = ReadLine();
        }while(UI.DateValidation(input) == false);
        pedido.Fecha = DateTime.Parse(input);

        do{
            ListLaboratories();
            WriteLine("Ingresa el laboratorio:");
            input = ReadLine();
            LabID = UI.GetLabID(input);
        } while (UI.LabValidation(LabID) == false);
        pedido.LaboratorioId =LabID;

        do{
            WriteLine("Ingresa la hora de entrega:");
            input = ReadLine();
        } while (UI.HourValidation(input) == false);
        pedido.HoraEntrega = DateTime.Parse($"{pedido.Fecha:yyyy-MM-dd} {input}");

        do{
            WriteLine("Ingresa la hora de devolucion:");
            input = ReadLine();
        } while (UI.HourValidation(input) == false);
        pedido.HoraDevolucion = DateTime.Parse($"{pedido.Fecha:yyyy-MM-dd} {input}");

        //Para que la fecha tome el valor de Hora de Entrega
        pedido.Fecha = DateTime.Parse($"{pedido.Fecha:yyyy-MM-dd} {pedido.HoraEntrega:HH:mm:ss}");

        using(Almacen db = new()){
            switch(typeOfUser){
                case 1:
                    Docente? docente = db.Docentes!.FirstOrDefault(r => r.UsuarioId == userID);
                    pedido.DocenteId = docente.DocenteId;
                    break;
                case 2:
                    GeneralSearchTeacher();
                    pedido.DocenteId = SearchId();
                    Estudiante? estudiante = db.Estudiantes!.FirstOrDefault(r => r.UsuarioId == userID);
                    pedido.EstudianteId = estudiante.EstudianteId; 
                    break;
                case 4:
                    Coordinador? coordinador = db.Coordinadores!.FirstOrDefault(r => r.UsuarioId == userID);
                    pedido.CoordinadorId = coordinador.CoordinadorId;
                    break;
            }
        }
        return pedido;
    }

    public static void ListCategories(int typeOfUser){
        using(Almacen db = new()){
            IQueryable<Categoria> categorias;
            if(typeOfUser == 2){
                categorias = db.Categorias.Where(categoria => categoria.Acceso == "1");
            }
            else if(typeOfUser == 1){
                categorias = db.Categorias.Where(c => c.Acceso == "1" || c.Acceso == "2");
            }
            else{
                categorias = db.Categorias;
            }
            if(categorias is null || (!categorias.Any())){
                Program.Fail("No hay categorias registrados");
                return;
            }
            WriteLine("{0,-3} | {1,-35} | {2,8} | {3,5} | {4}","Id","Nombre","Descripcion","","");
            foreach(var categoria in categorias){
                WriteLine($"{categoria.CategoriaId,-3} | {categoria.Nombre,-35} | {categoria.Descripcion,-14} |");
            }
            WriteLine();
        }
    }

    public static void ListOrders(int typeOfUser, int? userID){
        using(Almacen db = new()){
            if(db.Pedidos is null || (!db.Pedidos.Any())){
                Program.Fail("No hay pedidos registrados");
                return;
            }
            IQueryable<Pedido> pedidos;
            if(typeOfUser == 2){
                pedidos = db.Pedidos.Where(p => p.EstudianteId == userID);
            } 
            else if(typeOfUser == 1){
                pedidos = db.Pedidos.Where(p => p.DocenteId == userID && p.EstudianteId == null);
            }
            else if (typeOfUser == 4){
                pedidos = db.Pedidos.Where(p => p.CoordinadorId == userID);
            }
            else{
                pedidos = db.Pedidos;
            }
            WriteLine("{0,-2} | {1,-22} | {2,-13} | {3,-22} | {4,-22} | {5,-10} | {6,-10} | {7}","Id","Fecha","Laboratorio","Hora de Entrega","Hora de Devolucion","Estudiante","Docente","Aprovado");
            foreach(var pedido in pedidos){
                WriteLine($"{pedido.PedidoId,-2} | {pedido.Fecha,-22} | {pedido.Laboratorio.Nombre,-13} | {pedido.HoraEntrega,-22} | {pedido.HoraDevolucion,-5} | {pedido.Estudiante.Nombre,-10} | {pedido.Docente.Nombre,-10} | {(pedido.Estado ? "SI" : "NO")}");
            }
            WriteLine();
        }
    }
}