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
    public class UserModel : PageModel
    {
        private Almacen db;

        public UserModel(Almacen context)
        {
            db = context;
        }

        public List<Usuario>? usuarios { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "LogIn";
        }

        [BindProperty]
        public Usuario? Usuario { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Llama a la función de login desde tu programa de consola
                var result = UI.LogIn(Usuario.Usuario1, Usuario.Password);

                if (result.usuarioEncontrado != null)
                {
                    // Almacena la información del usuario en TempData
                    TempData["UserName"] = result.usuarioEncontrado.Usuario1;

                    Usuario usuario = result.usuarioEncontrado;

                    switch (result.typeOfUser)
                    {
                        case 1:
                            return RedirectToPage("/DocenteMenu", usuario);
                        case 2:
                            return RedirectToPage("/EstudianteMenu", usuario);
                        case 3:
                            return RedirectToPage("/AlmacenistaMenu", usuario);
                        case 4:
                            return RedirectToPage("/CoordinadorMenu", usuario);
                    }
                }
            }

            // Si las credenciales no son válidas o hay un error, permanece en la misma página
            return Page();
        }
    }
}
