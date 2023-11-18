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

        public void OnGet()
        {
            ViewData["Title"] = "LogIn";
        }

        [BindProperty]
        public Usuario? Usuario { get; set; }
        public Estudiante Estudiante {get; set;}
        public Person Person {get; set;}

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

        public IActionResult OnPostSignIn()
        {
            if (ModelState.IsValid)
            {
                Person person = new Person();
                Estudiante estudiante = new Estudiante();
                Usuario usuario = new Usuario();
            
                estudiante.EstudianteId = person.Registro;
                estudiante.Nombre = person.Nombre;
                estudiante.ApellidoPaterno = person.ApellidoPaterno;
                estudiante.ApellidoMaterno = person.ApellidoMaterno;
                estudiante.SemestreId = person.Semestre;
                estudiante.GrupoId = person.GrupoID;
                estudiante.PlantelId = person.plantel;
                estudiante.Correo = person.Correo;
                estudiante.Adeudo = 0;
                usuario.Usuario1 = person.newUsername;
                usuario.Password = person.Contrasena;
                usuario.Temporal = false;

                // Llama a la función AddStudent para agregar el nuevo estudiante y usuario
                CrudFuntions.AddStudent(estudiante,usuario);
                return RedirectToPage("/index");
            }

            // Si hay errores de validación, permanece en la misma página
            return Page();
        }
    }
}
