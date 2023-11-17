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
    public class PlantelModel : PageModel
    {
        private Almacen db;

        public PlantelModel(Almacen context)
        {
            db = context;
        }

        public List<Plantel>? plantels { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "";
        }

        [BindProperty]
        public Plantel? Plantel { get; set; }

        public IActionResult OnPost()
        {
        }
    }
}
