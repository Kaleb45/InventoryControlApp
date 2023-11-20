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
    public class UpdatesModel : PageModel
    {
        private Almacen db;

        public UpdatesModel(Almacen context)
        {
            db = context;
        }

        [BindProperty]
        public Categoria? categoria { get; set; } //1

        [BindProperty]
        public Material? material { get; set; } //2

        [BindProperty]
        public Marca? marca { get; set; } //3

        [BindProperty]
        public Modelo? modelo { get; set; } //4

        [BindProperty]
        public Mantenimiento? mantenimiento { get; set; } //5

        [BindProperty]
        public Estudiante? estudiante { get; set; } //6

        [BindProperty]
        public Docente? docente { get; set; } //7

        [BindProperty]
        public Almacenista? almacenista { get; set; } //8

        [BindProperty]
        public string tabla { get; set; }

        [BindProperty]
        public int userId { get; set; }

        [BindProperty]
        public string typeUser { get; set; }

        public void OnGet(int id, string table, int usuario, string tipo)
        {
            tabla = table;
            userId = usuario;
            typeUser = tipo;

            switch (table)
            {
                case "categoria":
                    categoria = db.Categorias!.FirstOrDefault(c => c.CategoriaId == id);
                    break;
                case "material":
                    material = db.Materiales!.FirstOrDefault(c => c.MaterialId == id);
                    break;
                case "marca":
                    marca = db.Marcas!.FirstOrDefault(c => c.MarcaId == id);
                    break;
                case "modelo":
                    modelo = db.Modelos!.FirstOrDefault(c => c.ModeloId == id);
                    break;
                default:
                    break;
            }
            ViewData["Title"] = "";
        }

        

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                TempData["UserType"] = 3;
                if(Request.Form["typeUser"] == "Almacenista"){
                    return RedirectToPage("/AlmacenistaMenu", new{id = int.Parse(Request.Form["userId"])});
                }
                else if(Request.Form["typeUser"] == "Coordinador"){
                    return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["userId"])});
                }
            }
            return Page();
        }

        public IActionResult OnPostUpdate()
        {
            if (!ModelState.IsValid)
            {
                int registroId = int.Parse(Request.Form["registroId"]);
                string tableId = Request.Form["tableId"];
                int userId = int.Parse(Request.Form["userId"]);
                string typeUser = Request.Form["typeUser"];
                switch (tableId){
                    case "categoria":
                        Categoria Upcategoria = db.Categorias!.FirstOrDefault(c => c.CategoriaId == registroId);
                        Upcategoria.Nombre = categoria.Nombre;
                        Upcategoria.Descripcion = categoria.Descripcion;
                        Upcategoria.Acceso = categoria.Acceso;
                        break;
                    case "material":
                        Material Upmaterial = db.Materiales!.FirstOrDefault(c => c.MaterialId == registroId);
                        Upmaterial.ModeloId = material.ModeloId;
                        Upmaterial.Descripcion = material.Descripcion;
                        Upmaterial.YearEntrada = material.YearEntrada;
                        Upmaterial.MarcaId = material.MarcaId;
                        Upmaterial.CategoriaId = material.CategoriaId;
                        Upmaterial.PlantelId = material.PlantelId;
                        Upmaterial.Serie = material.Serie;
                        Upmaterial.ValorHistorico = material.ValorHistorico;
                        Upmaterial.Condicion = material.Condicion;
                        break;
                    case "marca":
                        Marca Upmarca = db.Marcas!.FirstOrDefault(c => c.MarcaId == registroId);
                        Upmarca.Nombre = marca.Nombre;
                        Upmarca.Descripcion = marca.Descripcion;
                        break;
                    case "modelo":
                        Modelo Upmodelo = db.Modelos!.FirstOrDefault(c => c.ModeloId == registroId);
                        Upmodelo.Nombre = modelo.Nombre;
                        Upmodelo.Descripcion = modelo.Descripcion;
                        break;
                    default:
                        break;
                }
                db.SaveChanges();
                return RedirectToPage("/Updates", new{id = registroId, table = tableId, usuario = userId, tipo = typeUser});
            }
            return Page();
        }
    }
}
