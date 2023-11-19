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
                            return RedirectToPage("/DocenteMenu", new{id = docente.DocenteId});
                            break;
                        case 2:
                            Estudiante? alumno = db.Estudiantes!.FirstOrDefault(r => r.UsuarioId == result.usuarioEncontrado.UsuarioId);
                            return RedirectToPage("/EstudianteMenu", new{id = alumno.EstudianteId});
                            break;
                        case 3:
                            Almacenista? almacenista = db.Almacenistas!.FirstOrDefault(r => r.UsuarioId == result.usuarioEncontrado.UsuarioId);
                            return RedirectToPage("/AlmacenistaMenu", new{id = almacenista.AlmacenistaId});
                            break;
                        case 4:
                            Coordinador? coordinador = db.Coordinadores!.FirstOrDefault(r => r.UsuarioId == result.usuarioEncontrado.UsuarioId);
                            return RedirectToPage("/CoordinadorMenu", new{id = coordinador.CoordinadorId});
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
                int validationRegister = UI.RegisterValidation(estudiante.EstudianteId);

                switch (validationRegister)
                {
                    case 10:
                        return Page();
                    case 20:
                        return Page();
                    case 30:
                        return Page();
                    case 01:
                        // No hay error, proceder con la lógica normal
                        break;
                }
                
                int validationEmail = UI.StudentEmailValidation(estudiante.Correo, estudiante.EstudianteId);

                switch (validationEmail)
                {
                    case 10:
                        return Page();
                    case 20:
                        return Page();
                    case 30:
                        return Page();
                    case 40:
                        return Page();
                    case 50:
                        return Page();
                    case 70:
                        return Page();
                    case 80:
                        return Page();
                    case 100:
                        return Page();
                    case 01:
                        // No hay error, proceder con la lógica normal
                        break;
                }

                int validationPassword = UI.PasswordValidation(usuario.Password);
                
                switch (validationPassword)
                {
                    case 10:
                        return Page();
                    case 20:
                        return Page();
                    case 30:
                        return Page();
                    case 40:
                        return Page();
                    case 50:
                        return Page();
                    case 80:
                        return Page();
                    case 90:
                        return Page();
                    case 100:
                        return Page();
                    case 01:
                        // No hay error, proceder con la lógica normal
                        break;
                }

                estudiante.Adeudo = 0;
                usuario.Temporal = false;
                usuario.Usuario1 = UI.GenerateUsername(estudiante.Nombre, estudiante.ApellidoPaterno, estudiante.ApellidoMaterno);
                TempData["UserName"] = usuario.Usuario1;
                CrudFuntions.AddStudent(estudiante, usuario);
                //UI.NotificationUserName(estudiante);
                return RedirectToPage("/index", usuario.Usuario1);
            }
            else
            {
                return Page();
            }
        }
    }
}
