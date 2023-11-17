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
    public class MantenimientoModel : PageModel
    {
        private Almacen db;

        public MantenimientoModel(Almacen context)
        {
            db = context;
        }

        public List<Mantenimiento>? mantenimientos { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "";
        }

        [BindProperty]
        public Mantenimiento? Mantenimiento { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                
            }
            return Page();
        }
    }
}
