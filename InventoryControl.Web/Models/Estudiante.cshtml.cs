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

        public void OnGet(int id)
        {
            estudiante = db.Estudiantes.FirstOrDefault(e => e.EstudianteId == id);
            ViewData["Title"] = "";
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                
            }
            return Page();
        }
    }
}
