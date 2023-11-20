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
        [BindProperty]
        public Pedido? pedido { get; set; } = new();

        [BindProperty]
        public DescPedido? descPedido { get; set; }
        [BindProperty]
        public Categoria? categoria { get; set; }
        public void OnGet(int id)
        {
            estudiante = db.Estudiantes.FirstOrDefault(e => e.EstudianteId == id);
            TempData["UserType"] = 2;
            ViewData["Title"] = "";
            if (TempData.ContainsKey("Fecha"))
                pedido.Fecha = (DateTime)TempData["Fecha"];
            if (TempData.ContainsKey("HoraDevolucion"))
                pedido.HoraDevolucion = (DateTime)TempData["HoraDevolucion"];
            if (TempData.ContainsKey("LaboratorioId"))
                pedido.LaboratorioId = (int)TempData["LaboratorioId"];
            if (TempData.ContainsKey("DocenteId"))
                pedido.DocenteId = (int)TempData["DocenteId"];
            if (TempData.ContainsKey("CategoriaId"))
                categoria.CategoriaId = (int)TempData["CategoriaId"];
            if (TempData.ContainsKey("Cantidad"))
                descPedido.Cantidad = (int)TempData["Cantidad"];
        }

        public IActionResult OnPostNewOrder()
        {
            if ((pedido is not null) && (descPedido is not null) &&  !ModelState.IsValid)
            {
                TempData["UserType"] = 2;

                int validateHour = UI.DateValidationWeb(pedido.Fecha.ToString());
                switch (validateHour){
                    case 2:
                        return RedirectToPage("/EstudianteMenu", new{id = pedido.EstudianteId});
                    case 3:
                        return RedirectToPage("/EstudianteMenu", new{id = pedido.EstudianteId});
                    case 4:
                        return RedirectToPage("/EstudianteMenu", new{id = pedido.EstudianteId});
                    case 01:
                        // No hay error, proceder con la lógica normal
                        break;
                }

                if(UI.HourValidation(pedido.Fecha.ToString()) == false){
                    return RedirectToPage("/EstudianteMenu", new{id = pedido.EstudianteId});
                }

                pedido.HoraEntrega = pedido.Fecha;

                if(UI.HourValidation(pedido.HoraEntrega.ToString()) == false){
                    return RedirectToPage("/EstudianteMenu", new{id = pedido.EstudianteId});
                }

                if(pedido.HoraDevolucion <= pedido.HoraEntrega){
                    return RedirectToPage("/EstudianteMenu", new{id = pedido.EstudianteId});
                }

                descPedido.MaterialId = UI.GetMaterialID(categoria.CategoriaId);
                WriteLine($"{descPedido.MaterialId} |   {categoria.CategoriaId}");

                if(descPedido.MaterialId is null || descPedido.MaterialId == 0){
                    return RedirectToPage("/EstudianteMenu", new{id = pedido.EstudianteId});
                }

                WriteLine($"{pedido.EstudianteId}");
                CrudFuntions.AddPedido(pedido, descPedido);
                
                // Para enviarle el correo al docente
                estudiante = db.Estudiantes.FirstOrDefault(e => e.EstudianteId == pedido.EstudianteId);
                WriteLine($"{estudiante.EstudianteId}");
                //UI.SendNotTeacher(estudiante,descPedido,pedido);
                return RedirectToPage("/EstudianteMenu", new{id = pedido.EstudianteId});
            }
            return Page();
        }
    }
}
