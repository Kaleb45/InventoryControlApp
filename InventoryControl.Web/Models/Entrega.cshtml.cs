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
    public class EntregaModel : PageModel
    {
        private Almacen db;

        public EntregaModel(Almacen context)
        {
            db = context;
        }
        [BindProperty]
        public int userId { get; set; }

        [BindProperty]
        public string typeUser { get; set; }

        [BindProperty]
        public Material? material { get; set; }

        public void OnGet(int id, int usuario, string tipo){
            userId = usuario;
            typeUser = tipo;
            material = db.Materiales!.FirstOrDefault(c => c.MaterialId == id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                if(Request.Form["typeUser"] == "Almacenista"){
                    TempData["UserType"] = 3;
                    return RedirectToPage("/AlmacenistaMenu", new{id = int.Parse(Request.Form["userId"])});
                }
                else if(Request.Form["typeUser"] == "Coordinador"){
                    TempData["UserType"] = 4;
                    return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["userId"])});
                }
            }
            return Page();
        }

        public IActionResult OnPostNewEntrega()
        {
            if (!ModelState.IsValid)
            {
                int registroId = int.Parse(Request.Form["registroId"]);
                int userId = int.Parse(Request.Form["userId"]);
                string typeUser = Request.Form["typeUser"];
                Material Upmaterial = db.Materiales!.FirstOrDefault(c => c.MaterialId == registroId);
                Upmaterial.Condicion = material.Condicion;
                db.SaveChanges();
                if(Request.Form["typeUser"] == "Almacenista"){
                    TempData["UserType"] = 3;
                    return RedirectToPage("/EntregaMaterial", new{id = registroId, usuario = userId, tipo = typeUser});
                }
                else if(Request.Form["typeUser"] == "Coordinador"){
                    TempData["UserType"] = 4;
                    return RedirectToPage("/EntregaMaterial", new{id = registroId, usuario = userId, tipo = typeUser});
                }
            }
            return Page();
        }
        public IActionResult OnPostEntrega()
        {
            // Obtener el valor de pedidoId del formulario  
            int registroId = int.Parse(Request.Form["registroId"]);
            int userId = int.Parse(Request.Form["userId"]);
            string typeUser = Request.Form["typeUser"];
            return RedirectToPage("/EntregaMaterial", new{id = registroId, usuario = userId, tipo = typeUser});
        }
    }
}
