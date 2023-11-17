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
    public class GrupoModel : PageModel
    {
        private Almacen db;

        public GrupoModel(Almacen context)
        {
            db = context;
        }

        public List<Grupo>? grupos { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "";
        }

        [BindProperty]
        public Grupo? Grupo { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                
            }
            return Page();
        }
    }
}
