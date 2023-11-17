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
    public class CategoryModel : PageModel
    {
        private Almacen db;

        public CategoryModel(Almacen context)
        {
            db = context;
        }

        public List<Categoria>? categorias { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "";
        }

        [BindProperty]
        public Categoria? Categoria { get; set; }

        public IActionResult OnPost()
        {
        }
    }
}
