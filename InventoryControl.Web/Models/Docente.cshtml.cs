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

        public void OnGet()
        {
            ViewData["Title"] = "";
        }

        [BindProperty]
        public Docente? Docente { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                
            }
            return Page();
        }
    }
}
