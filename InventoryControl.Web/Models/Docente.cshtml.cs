using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using AlmacenSQLiteEntities;
using AlmacenDataContext;

namespace InventoryControlPages
{
    public class DocenteModel : PageModel
    {
        private Almacen db;

        public DocenteModel(Almacen context)
        {
            db = context;
        }

        public List<Docente>? docentes { get; set; }
        [BindProperty]
        public Docente? docente { get; set; }

        [BindProperty]
        public Pedido? pedido { get; set; } = new();

        [BindProperty]
        public DescPedido? descPedido { get; set; }
        [BindProperty]
        public Categoria? categoria { get; set; }

        public void OnGet(int id)
        {
            docente = db.Docentes.FirstOrDefault(e => e.DocenteId == id);
            TempData["UserType"] = 1;
            ViewData["Title"] = "";
            if (TempData.ContainsKey("Fecha"))
                pedido.Fecha = (DateTime)TempData["Fecha"];
            if (TempData.ContainsKey("HoraDevolucion"))
                pedido.HoraDevolucion = (DateTime)TempData["HoraDevolucion"];
        }

        public IActionResult OnPost()
        {
            if ((pedido is not null) && (descPedido is not null) &&  !ModelState.IsValid)
            {
                TempData["UserType"] = 1;
                TempData["Fecha"] = pedido.Fecha;
                TempData["HoraDevolucion"] = pedido.HoraDevolucion;

                int validateDate = UI.DateValidationWeb(pedido.Fecha.ToString());
                switch (validateDate){
                    case 2:
                        return RedirectToPage("/DocenteMenu", new{id = pedido.DocenteId});
                        break;
                    case 3:
                        return RedirectToPage("/DocenteMenu", new{id = pedido.DocenteId});
                        break;
                    case 4:
                        return RedirectToPage("/DocenteMenu", new{id = pedido.DocenteId});
                        break;
                    case 5:
                        return RedirectToPage("/DocenteMenu", new{id = pedido.DocenteId});
                        break;
                    case 1:
                        // No hay error, proceder con la lógica normal
                        break;
                }

                pedido.HoraEntrega = pedido.Fecha;
                
                if(UI.HourValidation(pedido.HoraEntrega.ToString()) == false){
                    RedirectToPage("/DocenteMenu", new{id = pedido.DocenteId});
                }


                if(UI.HourValidation(pedido.HoraDevolucion.ToString()) == false){
                    RedirectToPage("/DocenteMenu", new{id = pedido.DocenteId});
                }

                if(pedido.HoraDevolucion <= pedido.HoraEntrega){
                    RedirectToPage("/DocenteMenu", new{id = pedido.DocenteId});
                }

                descPedido.MaterialId = UI.GetMaterialID(categoria.CategoriaId);
                WriteLine($"{descPedido.MaterialId} |   {categoria.CategoriaId}");

                if(descPedido.MaterialId is null || descPedido.MaterialId == 0){
                    return RedirectToPage("/DocenteMenu", new{id = pedido.DocenteId});
                }

                pedido.Estado = true;

                CrudFuntions.AddPedido(pedido, descPedido);
                TempData["UserType"] = 1;
                return RedirectToPage("/DocenteMenu", new{id = pedido.DocenteId});
            }
            return Page();
        }
        public IActionResult OnPostApprove()
        {
            // Obtener el valor de pedidoId del formulario
            pedido = db.Pedidos.FirstOrDefault(p => p.PedidoId == int.Parse(Request.Form["pedidoId"]));
            pedido.Estado = true;
            Estudiante estudiante = db.Estudiantes.FirstOrDefault(e => e.EstudianteId == pedido.EstudianteId);
            int? DocenteIdAux = pedido.DocenteId;
            UI.SendEmailForOrderState(estudiante,"Datos incorrectos",pedido);
            db.SaveChanges();
            TempData["UserType"] = 1;
            return RedirectToPage("/DocenteMenu", new{id = pedido.DocenteId});
        }

        public IActionResult OnPostDecline()
        {
            // Obtener el valor de pedidoId del formulario            
            pedido = db.Pedidos.FirstOrDefault(p => p.PedidoId == int.Parse(Request.Form["pedidoId"]));
            pedido.Estado = false;
            descPedido = db.DescPedidos.FirstOrDefault(p => p.PedidoId == pedido.PedidoId);
            Estudiante estudiante = db.Estudiantes.FirstOrDefault(e => e.EstudianteId == pedido.EstudianteId);
            int? DocenteIdAux = pedido.DocenteId;
            UI.SendEmailForOrderState(estudiante,"Datos incorrectos",pedido);
            db.DescPedidos.RemoveRange(descPedido);
            db.Pedidos.RemoveRange(pedido);
            db.SaveChanges();
            TempData["UserType"] = 1;
            return RedirectToPage("/DocenteMenu", new{id = DocenteIdAux});
        }
    }
}
