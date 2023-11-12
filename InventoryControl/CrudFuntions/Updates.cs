using System;
using AlmacenDataContext;
using AlmacenSQLiteEntities;
public static partial class CrudFuntions
{
    public static int UpdateOrders(){
        using(Almacen db = new()){
            string? input;
            int LabID;
            int pedidoId;
            do{
                WriteLine("Que pedido quieres modificar?");
                input = ReadLine();
                pedidoId = UI.GetPedidoID(input);
            } while (UI.PedidoValidation(pedidoId) == false);
            Pedido? pedido = db.Pedidos!.FirstOrDefault(p => p.PedidoId == pedidoId);
            if((pedido is null)){
                Program.Fail("No se encontro un pedido para modificar");
                return 0;
            }
            else{
                Program.SectionTitle("¿Que quieres modificar?");
                WriteLine("1. Fecha");
                WriteLine("2. Laboratorio");
                WriteLine("3. Hora de Entrega");
                WriteLine("4. Hora de Devolucion");
                WriteLine("5. Estado de una solicitud");
                WriteLine("6. Cancelar modificacion");
                string? opcion = ReadLine();
                
                switch(opcion)
                {
                    case "1":
                    {
                        WriteLine($"Fecha actual: {pedido.Fecha}");
                        do{
                            WriteLine("Ingresa la fecha modificada: ");
                            input = ReadLine();
                        }while(UI.DateValidation(input) == false);
                        pedido.Fecha = DateTime.Parse($"{input} {pedido.HoraEntrega:HH:mm:ss}");
                        pedido.HoraEntrega = DateTime.Parse($"{pedido.Fecha:yyyy-MM-dd} {pedido.HoraEntrega:HH:mm:ss}");
                        pedido.HoraDevolucion = DateTime.Parse($"{pedido.Fecha:yyyy-MM-dd} {pedido.HoraDevolucion:HH:mm:ss}");
                        break;
                    }
                    case "2":
                    {
                        WriteLine($"Laboratorio actual: {pedido.Laboratorio.Nombre}");
                        do{
                            ListLaboratories();
                            WriteLine("Ingresa el laboratorio modificado:");
                            input = ReadLine();
                            LabID = UI.GetLabID(input);
                        } while (UI.LabValidation(LabID) == false);
                        pedido.LaboratorioId = LabID;
                        break;
                    }
                    case "3":
                    {
                        WriteLine($"Hora de entrega actual: {pedido.HoraEntrega:HH:mm:ss}");
                        do{
                            WriteLine("Ingresa la hora de entrega modificada:");
                            input = ReadLine();
                        } while (UI.HourValidation(input) == false);
                        pedido.HoraEntrega = DateTime.Parse($"{pedido.Fecha:yyyy-MM-dd} {input}");
                        pedido.Fecha = DateTime.Parse($"{pedido.Fecha:yyyy-MM-dd} {pedido.HoraEntrega:HH:mm:ss}");
                        break;
                    }
                    case "4":
                    {
                        WriteLine($"Hora de devolucion actual: {pedido.HoraDevolucion:HH:mm:ss}");
                        do{
                            WriteLine("Ingresa la hora de devolucion modificada:");
                            input = ReadLine();
                        } while (UI.HourValidation(input) == false);
                        pedido.HoraDevolucion = DateTime.Parse($"{pedido.Fecha:yyyy-MM-dd} {input}");
                        break;
                    }
                    case "5":
                        WriteLine($"Estado actual: {(pedido.Estado ? "SI" : "NO")}");
                        do{
                            WriteLine("¿Quiere aprobar o denegar el pedido?");
                            WriteLine("1. Aprovar");
                            WriteLine("2. Denegar");
                            input = ReadLine();
                        } while (input == "1\n" || input == "2\n");

                        input = input!.Trim();

                        if(input == "1"){
                            pedido.Estado = true;
                            Program.SectionTitle("Aprovado");
                        }
                        else if(input == "2"){
                            pedido.Estado = false;
                            db.SaveChanges();
                            Program.Fail("Denegado");
                        }
                        break;
                    case "6":
                        Program.Fail("Modificacion cancelada");
                        break;
                    default:
                        WriteLine("Opcion invalida");
                        break;
                }
                int affected = db.SaveChanges();
                return affected;
            }
        }
        return 0;
    }
}
