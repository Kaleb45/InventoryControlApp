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

        public void OnGet(int id)
        {
            docente = db.Docentes.FirstOrDefault(e => e.DocenteId == id);
            ViewData["Title"] = "";
        }

        public IActionResult OnPost()
        {
            if ((pedido is not null) && (descPedido is not null) &&  !ModelState.IsValid)
            {
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
