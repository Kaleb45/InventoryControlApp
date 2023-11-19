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
    public class EstudianteModel : PageModel
    {
        private Almacen db;

        public EstudianteModel(Almacen context)
        {
            db = context;
        }

        public List<Estudiante>? estudiantes { get; set; }

        [BindProperty]
        public Estudiante? estudiante { get; set; }
        [BindProperty]
        public Pedido? pedido { get; set; } = new();

        [BindProperty]
        public DescPedido? descPedido { get; set; }
        public void OnGet(int id)
        {
            estudiante = db.Estudiantes.FirstOrDefault(e => e.EstudianteId == id);
            ViewData["Title"] = "";
        }

        public IActionResult OnPost()
        {
            if ((pedido is not null) && (descPedido is not null) &&  !ModelState.IsValid)
            {
                WriteLine($"{pedido.EstudianteId}");
                //WriteLine($" {pedido.Fecha,-22} | | {pedido.HoraEntrega,-22} | {pedido.HoraDevolucion,-5}");
                CrudFuntions.AddPedido(pedido, descPedido);
                TempData["UserType"] = 2;
                return Page();
            }
            return Page();
        }
    }
}
