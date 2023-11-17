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
    public class ReporteMantenimientoModel : PageModel
    {
        private Almacen db;

        public ReporteMantenimientoModel(Almacen context)
        {
            db = context;
        }

        public List<ReporteMantenimiento>? reporteMantenimientos { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "";
        }

        [BindProperty]
        public ReporteMantenimiento? ReporteMantenimiento { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                
            }
            return Page();
        }
    }
}
