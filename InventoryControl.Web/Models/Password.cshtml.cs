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
    public class PasswordModel : PageModel
    {
        private Almacen db;

        public PasswordModel(Almacen context)
        {
            db = context;
        }

        public void OnGet()
        {
            ViewData["Title"] = "";
        }

        [BindProperty]
        public string? Email { get; set; }

        [BindProperty]
        public Usuario? usuario { get; set; }

        [BindProperty]
        public string? verificationCode { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                usuario = db.Usuarios.FirstOrDefault(u =>
                            u.Almacenistas.Any(a => a.Correo == Email) ||
                            u.Coordinadores.Any(c => c.Correo == Email) ||
                            u.Docentes.Any(d => d.Correo == Email) ||
                            u.Estudiantes.Any(e => e.Correo == Email));
                if (usuario != null)
                {
                    string verificationCode = UI.GenerateRandomString();
                    TempData["VerificationCode"] = verificationCode;
                    UI.SendVerificationCodeByEmail(Email, verificationCode);
                    return RedirectToPage("/VerificationPage", new {userId = usuario.UsuarioId });
                }
                ModelState.AddModelError(string.Empty, "No se encontró un usuario con ese correo electrónico.");
            }
            return Page();
        }

        public IActionResult OnPostIndex()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("/index");
            }
            return Page();
        }
    }
}
