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
using InventoryControl.UI;

namespace InventoryControl.Pages
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
                    // Redirige al menú correspondiente según el tipo de usuario
                    UI.MenuSelected(result.usuarioEncontrado, result.typeOfUser);
                    return RedirectToPage("/Menu"); // Asegúrate de que la página exista
                }
            }

            // Si las credenciales no son válidas o hay un error, permanece en la misma página
            return Page();
        }

        static public IActionResult MenuSelected(Usuario currentUser, int typeOfUser)
        {
            switch (typeOfUser)
            {
                case 1:
                    return RedirectToPage("/DocenteMenu"); // Reemplaza con la página de menú de docente
                case 2:
                    return RedirectToPage("/EstudianteMenu"); // Reemplaza con la página de menú de estudiante
                case 3:
                    return RedirectToPage("/AlmacenistaMenu"); // Reemplaza con la página de menú de almacenista
                case 4:
                    return RedirectToPage("/CoordinadorMenu"); // Reemplaza con la página de menú de coordinador
                default:
                    // Manejar cualquier otro caso aquí, posiblemente una página de error
                    return RedirectToPage("/Menu");
            }
        }
    }
}
