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
        public List<Estudiante>? estudiantes { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "LogIn";
        }

        [BindProperty]
        public Usuario? usuario { get; set; }
        [BindProperty]
        public Estudiante? estudiante {get; set;}

        public IActionResult OnPost()
        {
            if ((usuario is not null) &&!ModelState.IsValid)
            {
                // Llama a la función de login desde tu programa de consola
                var result = UI.LogIn(usuario.Usuario1, usuario.Password);

                if (result.usuarioEncontrado != null)
                {
                    // Almacena la información del usuario en TempData
                    TempData["UserName"] = result.usuarioEncontrado.Usuario1;

                    switch(result.typeOfUser){
                        case 1:
                            Docente? docente = db.Docentes!.FirstOrDefault(r => r.UsuarioId == result.usuarioEncontrado.UsuarioId);
                            return RedirectToPage("/DocenteMenu", docente);
                            break;
                        case 2:
                            Estudiante? alumno = db.Estudiantes!.FirstOrDefault(r => r.UsuarioId == result.usuarioEncontrado.UsuarioId);
                            return RedirectToPage("/EstudianteMenu", alumno);
                            break;
                        case 3:
                            Almacenista? almacenista = db.Almacenistas!.FirstOrDefault(r => r.UsuarioId == result.usuarioEncontrado.UsuarioId);
                            return RedirectToPage("/AlmacenistaMenu", almacenista);
                            break;
                        case 4:
                            Coordinador? coordinador = db.Coordinadores!.FirstOrDefault(r => r.UsuarioId == result.usuarioEncontrado.UsuarioId);
                            return RedirectToPage("/CoordinadorMenu", coordinador);
                            break;
                    }
                }
            }

            // Si las credenciales no son válidas o hay un error, permanece en la misma página
            return Page();
        }

        public IActionResult OnPostSignIn()
        {
             if ((estudiante is not null) && !ModelState.IsValid)
            {
                CrudFuntions.AddStudent(estudiante,usuario);
                return RedirectToPage("/index");
            }
            else
            {
                return Page();
            }
        }
    }
}
