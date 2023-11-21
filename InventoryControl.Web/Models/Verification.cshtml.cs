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
    public class VerificationModel : PageModel
    {
        private Almacen db;

        public VerificationModel(Almacen context)
        {
            db = context;
        }

        [BindProperty]
        public string? Code { get; set; }

        [HttpGet]
        public void OnGet(int userId)
        {
            TempData["userId"] = userId;
            ViewData["Title"] = "";
        } 

        [HttpPost]
        public IActionResult OnPost()
        {
            string savedCode = TempData["VerificationCode"].ToString();
            try
            {
                if (Code == savedCode)
                {
                    if (string.Equals(Request.Form["Code"], savedCode))
                    {
                        return RedirectToPage("/NewPassword", new{id = int.Parse(TempData["userId"].ToString())});
                    }
                    else{
                        TempData["VerificationCode"] = savedCode;
                    }
                }
                else{
                    TempData["VerificationCode"] = savedCode;
                }
                ModelState.AddModelError(string.Empty, "El código es incorrecto.");
                return Page();
            }
            catch (Exception ex)
            {
                throw; // O manejar el error según sea necesario.
            }
        }
        public IActionResult OnPostIndex()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("/index");
            }
            return Page();
        }
    }
}
